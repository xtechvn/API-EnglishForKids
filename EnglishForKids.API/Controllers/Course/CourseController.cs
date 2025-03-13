using HuloToys_Service.Controllers.News.Business;
using HuloToys_Service.Models.APIRequest;
using HuloToys_Service.Models.Article;
using HuloToys_Service.Models.ElasticSearch;
using HuloToys_Service.RedisWorker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Utilities.Contants;
using Utilities;
using HuloToys_Service.Models.Course;
using Newtonsoft.Json;
using HuloToys_Service.Utilities.Lib;
using Microsoft.EntityFrameworkCore;
using HuloToys_Service.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HuloToys_Service.Controllers.Course
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        public IConfiguration configuration;
        private readonly RedisConn _redisService;
        private readonly CourseBusiness _courseBusiness;
        private readonly ApplicationDbContext _dbContext;
        public CourseController(IConfiguration config, RedisConn redisService, ApplicationDbContext dbContext)
        {
            configuration = config;

            _redisService = redisService;
            _redisService = new RedisConn(config);
            _redisService.Connect();
            _courseBusiness = new CourseBusiness(configuration);
            _dbContext = dbContext;

        }

        [HttpPost("get-list-courses.json")]
        public async Task<ActionResult> getListCourse([FromBody] APIRequestGenericModel input)
        {
            try
            {
                JArray objParr = null;
                if (CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    int node_redis = Convert.ToInt32(configuration["Redis:Database:db_course"]);
                    var _category_detail = new GroupProductModel();
                    var list_course = new List<CourseModel>();
                    int total_max_cache = 100; // số bản ghi tối đa để cache    
                    int category_id = Convert.ToInt32(objParr[0]["category_id"]);

                    int skip = Convert.ToInt32(objParr[0]["skip"]);
                    int top = Convert.ToInt32(objParr[0]["top"]);

                    string cache_name = CacheType.COURSE_LISTING + category_id;
                    var j_data = await _redisService.GetAsync(cache_name, node_redis);

                    // Kiểm tra có trong cache không ?
                    if (!string.IsNullOrEmpty(j_data))
                    {
                        list_course = JsonConvert.DeserializeObject<List<CourseModel>>(j_data);
                        // Nếu tổng số bản ghi muốn lấy vượt quá số bản ghi trong Redis thì vào ES lấy                        
                        if (top > list_course.Count())
                        {
                            // Lấy ra trong es
                            list_course = await _courseBusiness.getListCourse(category_id, top);
                        }
                    }
                    else // Không có trong cache
                    {
                        // Lấy ra số bản ghi tối đa để cache
                        list_course = await _courseBusiness.getListCourse(category_id, Math.Max(total_max_cache, top));

                        if (list_course.Count() > 0)
                        {
                            _redisService.Set(cache_name, JsonConvert.SerializeObject(list_course), node_redis);
                        }
                    }

                    if (list_course != null && list_course.Count() > 0)
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.SUCCESS,
                            data = list_course.ToList().Skip(skip).Take(top)
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.EMPTY,
                            msg = "data empty !!!"
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        status = (int)ResponseType.ERROR,
                        msg = "Key ko hop le"
                    });
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = "Error: " + ex.ToString(),
                });
            }
        }
        [AllowAnonymous]  // ✅ Bỏ xác thực chỉ với API này

        [HttpPost("submit-answer.json")]
        public async Task<ActionResult> SubmitQuizAnswer([FromBody] SubmitQuizAnswer request)
        {
            try
            {
                int userId = request.UserId;
                int quizId = request.QuizId;
                int quizAnswerId = request.QuizAnswerId;
                int sourceId = request.SourceId;
                int quizResultId = 0; // 🟢 Mặc định 0, nếu đã có sẽ cập nhật
                int newQuizResultId;
                // 1️⃣ Kiểm tra xem user đã làm câu hỏi này chưa
                var existingResult = await _dbContext.QuizResult
                    .Where(qr => qr.UserId == userId && qr.QuizId == quizId)
                    .OrderByDescending(qr => qr.CreatedDate) // Lấy bản ghi gần nhất
                    .FirstOrDefaultAsync();

                if (existingResult != null)
                {
                    quizResultId = existingResult.Id; // 🟢 Nếu có kết quả, lấy `Id` để cập nhật
                }
                // 1️⃣ Lưu kết quả của user qua Stored Procedure
                var identityParam = new SqlParameter("@Identity", SqlDbType.Int) { Direction = ParameterDirection.Output };
                if (existingResult != null)
                {
                    await _dbContext.Database.ExecuteSqlRawAsync(
                     "EXEC [dbo].[sp_UpdateQuizResult] @Id, @SourceId, @QuizId, @QuizAnswerId, @UserId, @UpdatedBy, @Identity OUT",
                     new SqlParameter("@Id", quizResultId), // ID mới (0 nghĩa là tạo mới)
                     new SqlParameter("@SourceId", sourceId),
                     new SqlParameter("@QuizId", quizId),
                     new SqlParameter("@QuizAnswerId", quizAnswerId),
                     new SqlParameter("@UserId", userId),
                     new SqlParameter("@UpdatedBy", userId),
                     identityParam
                );

                    newQuizResultId = (int)identityParam.Value;
                }
                else
                {
                    // 3️⃣ Nếu user chưa làm câu hỏi này trước đó, thêm mới bằng Stored Procedure
                    await _dbContext.Database.ExecuteSqlRawAsync(
                     "EXEC [dbo].[sp_InsertQuizResult] @SourceId, @QuizId, @QuizAnswerId, @UserId, @CreatedBy, @CreatedDate, @Identity OUT",
                     new SqlParameter("@SourceId", sourceId),
                     new SqlParameter("@QuizId", quizId),
                     new SqlParameter("@QuizAnswerId", quizAnswerId),
                     new SqlParameter("@UserId", userId),
                     new SqlParameter("@CreatedBy", userId),
                     new SqlParameter("@CreatedDate", DateTime.UtcNow),
                     identityParam
                     );

                    newQuizResultId = (int)identityParam.Value;
                }


                // 2️⃣ Lấy danh sách đáp án của quiz từ Database
                var allAnswers = await _dbContext.QuizAnswer
                    .Where(a => a.QuizId == request.QuizId)
                    .ToListAsync();

                if (!allAnswers.Any())
                {
                    return BadRequest(new QuizResultResponse
                    {
                        status = 1,
                        Message = "Không tìm thấy đáp án cho câu hỏi này."
                    });
                }

                // 3️⃣ Kiểm tra đáp án
                var correctAnswer = allAnswers.FirstOrDefault(a => a.IsCorrectAnswer);
                if (correctAnswer == null)
                {
                    return BadRequest(new QuizResultResponse
                    {
                        status = 1,
                        Message = "Không tìm thấy đáp án đúng."
                    });
                }
                var userAnswer = allAnswers.FirstOrDefault(a => a.Id == request.QuizAnswerId);
                if (userAnswer == null)
                {
                    return BadRequest(new QuizResultResponse
                    {
                        status = 1,
                        Message = "Đáp án không hợp lệ."
                    });
                }
                bool isCorrect = userAnswer?.IsCorrectAnswer ?? false;

                return Ok(new QuizResultResponse
                {
                    status = (int)ResponseType.SUCCESS,
                    IsCorrect = isCorrect,
                    CorrectAnswerNote = correctAnswer.Note, // Luôn gửi lời giải thích
                    Message = isCorrect ? "Chính xác! Bạn đã trả lời đúng." : "Sai rồi! Hãy xem lại gợi ý."
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = "Lỗi hệ thống: " + ex.ToString()
                });
            }
        }


        [AllowAnonymous]
        [HttpPost("get-lesson-detail.json")]
        public async Task<IActionResult> GetLessonDetail([FromBody] LessonDetail request)
        {
            try
            {
                // 🔥 Lấy dữ liệu khóa học từ Redis
                string redisKey = $"COURSE_DETAIL_{request.CourseId}";
                int redisDbIndex = int.Parse(configuration["Redis:Database:db_course"]);
                string redisData = await _redisService.GetAsync(redisKey, redisDbIndex);

                if (string.IsNullOrEmpty(redisData))
                {
                    return NotFound(new { success = false, message = "Không tìm thấy khóa học." });
                }

                // 🛑 Deserialize JSON thành object
                var courseModel = JsonConvert.DeserializeObject<CourseDetailViewModel>(redisData);
                if (courseModel == null || courseModel.Chapters == null)
                {
                    return NotFound(new { success = false, message = "Dữ liệu khóa học không hợp lệ." });
                }

                // 🔎 Tìm bài học hoặc quiz theo LessonId hoặc QuizId
                var lesson = courseModel.Chapters
                    .SelectMany(c => c.Items)
                    .FirstOrDefault(i => i.LessonId == request.LessonId);

                var quiz = courseModel.Chapters
                    .SelectMany(c => c.Items)
                    .FirstOrDefault(i => i.QuizId == request.LessonId); // Lấy Quiz nếu LessonId thực chất là QuizId

                // ✅ Nếu là bài giảng (Lesson)
                if (lesson != null)
                {
                    return Ok(new
                    {
                        videoUrl = lesson.Files?.FirstOrDefault(f => f.Type == 40 && f.Path.EndsWith(".mp4"))?.Path,
                        audioUrl = lesson.Files?.FirstOrDefault(f => f.Type == 40 && f.Path.EndsWith(".mp3"))?.Path,
                        articleContent = lesson.Article,
                        articleFilesJson = lesson.Files?.Where(f => f.Type == 50).Select(f => new
                        {
                            name = System.IO.Path.GetFileName(f.Path),
                            path = f.Path
                        }),
                        quizDataJson = new List<object>() // Không có quiz
                    });
                }

                // ✅ Nếu là Quiz (trả về câu hỏi của Quiz)
                if (quiz != null)
                {
                    return Ok(new
                    {
                        videoUrl = (string)null,
                        audioUrl = (string)null,
                        articleContent = (string)null,
                        articleFilesJson = new List<object>(),
                        quizDataJson = quiz.Questions?.Select(q => new
                        {
                            questionId = q.QuestionId,
                            questionText = q.Description,
                            options = q.Answers?.Select(a => new
                            {
                                optionId = a.AnswerId,
                                optionText = a.Description
                            })
                        })
                    });
                }

                return NotFound(new { success = false, message = "Không tìm thấy bài học hoặc quiz." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi hệ thống", error = ex.Message });
            }
        }


        //[AllowAnonymous]
        //[HttpPost("get-results.json")]
        //public async Task<ActionResult> GetQuizResults([FromBody] GetQuizResultRequest request)
        //{
        //    try
        //    {
        //        int userId = request.UserId;
        //        int quizParentId = request.QuizId;

        //        // 1️⃣ Lấy danh sách các Sub-Quiz
        //        var subQuizIds = await _dbContext.Quiz
        //            .Where(q => q.ParentId == quizParentId)
        //            .Select(q => q.Id)
        //            .ToListAsync();

        //        if (!subQuizIds.Any())
        //        {
        //            return BadRequest(new QuizProgressResponse
        //            {
        //                Status = 1,
        //                Message = "Không tìm thấy Sub-Quiz nào."
        //            });
        //        }

        //        // 2️⃣ Lấy danh sách kết quả của user
        //        var userResults = await _dbContext.QuizResult
        //            .Where(r => subQuizIds.Contains(r.QuizId) && r.UserId == userId)
        //            .ToListAsync();

        //        // 3️⃣ Lấy danh sách câu hỏi của Quiz
        //        var allQuizQuestions = await _dbContext.Quiz
        //            .Where(q => subQuizIds.Contains(q.Id))
        //            .OrderBy(q => q.Id) // ✅ Giữ nguyên thứ tự câu hỏi theo ID
        //            .Select(q => new QuestionModel
        //            {
        //                QuestionId = q.Id,
        //                Description = q.Description,
        //                Answers = _dbContext.QuizAnswer
        //                    .Where(ans => ans.QuizId == q.Id)
        //                    .Select(ans => new AnswerModel
        //                    {
        //                        AnswerId = ans.Id,
        //                        Description = ans.Description,
        //                        IsCorrect = ans.IsCorrectAnswer,
        //                        Note = ans.Note
        //                    }).ToList()
        //            })
        //            .ToListAsync();

        //        if (!allQuizQuestions.Any())
        //        {
        //            return BadRequest(new QuizProgressResponse
        //            {
        //                Status = 1,
        //                Message = "Không tìm thấy câu hỏi nào."
        //            });
        //        }

        //        // 4️⃣ Xác định danh sách câu hỏi đã làm và chưa làm
        //        var answeredQuestionIds = userResults.Select(r => r.QuizId).ToList();
        //        var allQuestionIds = allQuizQuestions.Select(q => q.QuestionId).ToList();
        //        var skippedQuestionIds = allQuestionIds.Except(answeredQuestionIds).ToList();

        //        // ✅ 5️⃣ Xác định **câu chưa làm đầu tiên** theo thứ tự ban đầu
        //        var nextQuestionIndex = allQuizQuestions.FindIndex(q => skippedQuestionIds.Contains(q.QuestionId));
        //        var nextQuestion = nextQuestionIndex != -1 ? allQuizQuestions[nextQuestionIndex] : null;
        //        bool isCompleted = skippedQuestionIds.Count == 0;

        //        // ✅ 6️⃣ **Giữ nguyên thứ tự câu hỏi, chỉ đánh dấu câu nào đã làm**
        //        var allQuestionsWithStatus = allQuizQuestions
        //            .Select(q => new QuestionModel
        //            {
        //                QuestionId = q.QuestionId,
        //                Description = q.Description,
        //                Answers = q.Answers,
        //                IsAnswered = answeredQuestionIds.Contains(q.QuestionId), // ✅ Đánh dấu câu đã làm
        //                SelectedAnswer = userResults.FirstOrDefault(r => r.QuizId == q.QuestionId)?.QuizAnswerId // ✅ Nếu đã làm, lấy câu trả lời đã chọn
        //            })
        //            .ToList();

        //        // ✅ 7️⃣ **Fix lỗi `CorrectAnswers` chỉ lấy đáp án đã chọn**
        //        var correctAnswers = userResults
        //            .Where(r => _dbContext.QuizAnswer.Any(a => a.Id == r.QuizAnswerId && a.IsCorrectAnswer))
        //            .Select(r => new QuestionModel
        //            {
        //                QuestionId = r.QuizId,
        //                Description = allQuizQuestions.First(q => q.QuestionId == r.QuizId).Description,
        //                Answers = allQuizQuestions.First(q => q.QuestionId == r.QuizId).Answers
        //                    .Where(a => a.AnswerId == r.QuizAnswerId)
        //                    .ToList()
        //            })
        //            .ToList();

        //        var incorrectAnswers = userResults
        //            .Where(r => _dbContext.QuizAnswer.Any(a => a.Id == r.QuizAnswerId && !a.IsCorrectAnswer))
        //            .Select(r => new QuestionModel
        //            {
        //                QuestionId = r.QuizId,
        //                Description = allQuizQuestions.First(q => q.QuestionId == r.QuizId).Description,
        //                Answers = allQuizQuestions.First(q => q.QuestionId == r.QuizId).Answers
        //                    .Where(a => a.AnswerId == r.QuizAnswerId)
        //                    .ToList()
        //            })
        //            .ToList();

        //        // ✅ 8️⃣ **Trả về kết quả với thứ tự câu hỏi ban đầu**
        //        return Ok(new QuizProgressResponse
        //        {
        //            Status = (int)ResponseType.SUCCESS,
        //            Completed = isCompleted,
        //            NextQuestionIndex = nextQuestionIndex != -1 ? nextQuestionIndex : 0, // ✅ Không đảo vị trí câu hỏi
        //            CorrectCount = correctAnswers.Count,
        //            CorrectAnswers = correctAnswers,
        //            IncorrectAnswers = incorrectAnswers,
        //            SkippedQuestions = nextQuestion != null ? new List<QuestionModel> { nextQuestion } : new List<QuestionModel>(),
        //            AllQuestions = allQuestionsWithStatus,
        //            Message = isCompleted ? "Người dùng đã hoàn thành quiz." : "Tiếp tục làm bài."
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new
        //        {
        //            Status = (int)ResponseType.FAILED,
        //            Message = "Lỗi hệ thống: " + ex.ToString()
        //        });
        //    }
        //}

        [AllowAnonymous]
        [HttpPost("get-results.json")]
        public async Task<ActionResult> GetQuizResults([FromBody] GetQuizResultRequest request)
        {
            try
            {
                int userId = request.UserId;
                int quizParentId = request.QuizId;

                var subQuizIds = await _dbContext.Quiz
                    .Where(q => q.ParentId == quizParentId)
                    .Select(q => q.Id)
                    .ToListAsync();

                if (!subQuizIds.Any())
                {
                    return BadRequest(new QuizProgressResponse
                    {
                        Status = 1,
                        Message = "Không tìm thấy Sub-Quiz nào."
                    });
                }

                var userResults = await _dbContext.QuizResult
                    .Where(r => subQuizIds.Contains(r.QuizId) && r.UserId == userId)
                    .ToListAsync();

                var allQuizQuestions = await _dbContext.Quiz
                    .Where(q => subQuizIds.Contains(q.Id) && q.IsDelete == 0)
                    .OrderBy(q => q.Id)
                    .Select(q => new QuestionModel
                    {
                        QuestionId = q.Id,
                        Description = q.Description,
                        Answers = _dbContext.QuizAnswer
                            .Where(ans => ans.QuizId == q.Id)
                            .Select(ans => new AnswerModel
                            {
                                AnswerId = ans.Id,
                                Description = ans.Description,
                                IsCorrect = ans.IsCorrectAnswer,
                                Note = ans.Note
                            }).ToList()
                    })
                    .ToListAsync();

                if (!allQuizQuestions.Any())
                {
                    return BadRequest(new QuizProgressResponse
                    {
                        Status = 1,
                        Message = "Không tìm thấy câu hỏi nào."
                    });
                }

                var answeredQuestionIds = userResults.Select(r => r.QuizId).ToList();
                var allQuestionIds = allQuizQuestions.Select(q => q.QuestionId).ToList();
                var skippedQuestionIds = allQuestionIds.Except(answeredQuestionIds).ToList();

                var correctAnswers = allQuizQuestions
                    .Where(q => answeredQuestionIds.Contains(q.QuestionId) &&
                                userResults.Any(r => r.QuizId == q.QuestionId && q.Answers.Any(a => a.AnswerId == r.QuizAnswerId && a.IsCorrect)))
                    .Select(q => new QuestionModel
                    {
                        QuestionId = q.QuestionId,
                        Description = q.Description,
                        Answers = q.Answers.Where(a => userResults.Any(ur => ur.QuizAnswerId == a.AnswerId)).ToList()
                    })
                    .ToList();

                var incorrectAnswers = allQuizQuestions
                    .Where(q => answeredQuestionIds.Contains(q.QuestionId) &&
                                userResults.Any(r => r.QuizId == q.QuestionId && q.Answers.Any(a => a.AnswerId == r.QuizAnswerId && !a.IsCorrect)))
                    .Select(q => new QuestionModel
                    {
                        QuestionId = q.QuestionId,
                        Description = q.Description,
                        Answers = q.Answers.Where(a => userResults.Any(ur => ur.QuizAnswerId == a.AnswerId)).ToList()
                    })
                    .ToList();

                // ✅ 6️⃣ **Trả về tất cả câu bị bỏ qua**
                var skippedQuestions = allQuizQuestions
                    .Where(q => skippedQuestionIds.Contains(q.QuestionId))
                    .ToList();

                int nextQuestionIndex = skippedQuestions.Any() ? allQuizQuestions.FindIndex(q => q.QuestionId == skippedQuestions.First().QuestionId) : 0;

                return Ok(new QuizProgressResponse
                {
                    Status = (int)ResponseType.SUCCESS,
                    Completed = skippedQuestions.Count == 0,
                    NextQuestionIndex = nextQuestionIndex,
                    CorrectCount = correctAnswers.Count,
                    CorrectAnswers = correctAnswers,
                    IncorrectAnswers = incorrectAnswers,
                    SkippedQuestions = skippedQuestions,
                    AllQuestions = allQuizQuestions.Select(q => new QuestionModel
                    {
                        QuestionId = q.QuestionId,
                        Description = q.Description,
                        Answers = q.Answers,
                        IsAnswered = answeredQuestionIds.Contains(q.QuestionId),
                        SelectedAnswer = userResults.FirstOrDefault(r => r.QuizId == q.QuestionId)?.QuizAnswerId
                    }).ToList(),
                    Message = skippedQuestions.Count == 0 ? "Người dùng đã hoàn thành quiz." : "Tiếp tục làm bài."
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Status = (int)ResponseType.FAILED,
                    Message = "Lỗi hệ thống: " + ex.ToString()
                });
            }
        }


        [AllowAnonymous]
        [HttpPost("reset-quiz.json")]
        public async Task<ActionResult> ResetQuiz([FromBody] GetQuizResultRequest request)
        {
            try
            {
                int userId = request.UserId;
                int quizParentId = request.QuizId;

                // 🛑 Xóa kết quả quiz của User dựa trên Quiz cha
                var subQuizIds = await _dbContext.Quiz
                    .Where(q => q.ParentId == quizParentId)
                    .Select(q => q.Id)
                    .ToListAsync();

                if (!subQuizIds.Any())
                {
                    return BadRequest(new { status = 1, message = "Không tìm thấy Sub-Quiz nào để xóa." });
                }

                await _dbContext.QuizResult
                    .Where(r => r.UserId == userId && subQuizIds.Contains(r.QuizId))
                    .ExecuteDeleteAsync();

                return Ok(new { status = 0, message = "Đã reset quiz thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 1, message = "Lỗi hệ thống: " + ex.Message });
            }
        }






        //[HttpPost("submit-answer.json")]
        //public async Task<ActionResult> SubmitQuizAnswer([FromBody] APIRequestGenericModel input)
        //{
        //    try
        //    {
        //        JArray objParr = null;
        //        if (CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
        //        {
        //            int userId = Convert.ToInt32(objParr[0]["userId"]);
        //            int quizId = Convert.ToInt32(objParr[0]["quizId"]);
        //            int quizAnswerId = Convert.ToInt32(objParr[0]["quizAnswerId"]);
        //            int sourceId = Convert.ToInt32(objParr[0]["sourceId"]);

        //            // 1️⃣ Lưu kết quả của user vào `QuizResult`
        //            var quizResult = new QuizResult
        //            {
        //                SourceId = sourceId,
        //                QuizId = quizId,
        //                QuizAnswerId = quizAnswerId,
        //                UserId = userId,
        //                CreatedBy = userId,
        //                CreatedDate = DateTime.UtcNow
        //            };

        //            await _dbContext.QuizResults.AddAsync(quizResult);
        //            await _dbContext.SaveChangesAsync();

        //            // 2️⃣ Lấy danh sách tất cả đáp án của quiz từ Database
        //            var allAnswers = await _dbContext.QuizAnswers
        //                .Where(a => a.QuizId == quizId)
        //                .ToListAsync();

        //            if (!allAnswers.Any())
        //            {
        //                return Ok(new
        //                {
        //                    status = (int)ResponseType.EMPTY,
        //                    msg = "Không tìm thấy đáp án cho câu hỏi này."
        //                });
        //            }

        //            // 3️⃣ Tìm đáp án đúng
        //            var correctAnswer = allAnswers.FirstOrDefault(a => a.IsCorrectAnswer);

        //            if (correctAnswer == null)
        //            {
        //                return Ok(new
        //                {
        //                    status = (int)ResponseType.ERROR,
        //                    msg = "Không tìm thấy đáp án đúng."
        //                });
        //            }

        //            // 4️⃣ Tìm đáp án mà user đã chọn
        //            var userAnswer = allAnswers.FirstOrDefault(a => a.Id == quizAnswerId);

        //            if (userAnswer == null)
        //            {
        //                return Ok(new
        //                {
        //                    status = (int)ResponseType.ERROR,
        //                    msg = "Đáp án không hợp lệ."
        //                });
        //            }

        //            // 5️⃣ Xác định đúng hay sai
        //            bool isCorrect = userAnswer.IsCorrectAnswer;

        //            return Ok(new
        //            {
        //                status = (int)ResponseType.SUCCESS,
        //                isCorrect = isCorrect,
        //                correctAnswerNote = correctAnswer.Note, // Luôn gửi lời giải thích
        //                message = isCorrect ? "Chính xác! Bạn đã trả lời đúng." : "Sai rồi! Hãy xem lại gợi ý."
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                status = (int)ResponseType.ERROR,
        //                msg = "Key không hợp lệ"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
        //        LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
        //        return Ok(new
        //        {
        //            status = (int)ResponseType.FAILED,
        //            msg = "Lỗi hệ thống: " + ex.ToString(),
        //        });
        //    }
        //}

        [HttpPost("get-total-courses.json")]
        public async Task<ActionResult> getTotalItemCourseByCategoryId([FromBody] APIRequestGenericModel input)
        {
            try
            {
                JArray objParr = null;
                if (CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    int category_id = Convert.ToInt32(objParr[0]["category_id"]);
                    // Lấy ra trong es
                    var total = await _courseBusiness.getTotalItemCoursesByCategoryId(category_id);
                    return Ok(new
                    {
                        status = (int)ResponseType.SUCCESS,
                        data = total
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = (int)ResponseType.ERROR,
                        msg = "Key ko hop le"
                    });
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = "Error: " + ex.ToString(),
                });
            }
        }
        /// <summary>
        /// Lấy ra chi tiết bài viết
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //[HttpPost("get-courses-detail.json")]
        //public async Task<ActionResult> getArticleDetail([FromBody] APIRequestGenericModel input)
        //{
        //    try
        //    {
        //        int node_redis = Convert.ToInt32(configuration["Redis:Database:db_course"]);
        //        JArray objParr = null;
        //        if (CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
        //        {
        //            var article_detail = new CourseModel();

        //            long article_id = Convert.ToInt64(objParr[0]["courses_id"]);

        //            string cache_name = CacheType.COURSE_ID + article_id;
        //            var j_data = await _redisService.GetAsync(cache_name, node_redis);

        //            // Kiểm tra có trong cache không ?
        //            if (!string.IsNullOrEmpty(j_data))
        //            {
        //                article_detail = JsonConvert.DeserializeObject<CourseModel>(j_data);
        //            }
        //            else // Không có trong cache
        //            {
        //                article_detail = await _newsBusiness.getArticleDetail(article_id);

        //                if (article_detail != null)
        //                {
        //                    _redisService.Set(cache_name, JsonConvert.SerializeObject(article_detail), node_redis);
        //                }
        //            }

        //            if (article_detail != null)
        //            {

        //                return Ok(new
        //                {
        //                    status = (int)ResponseType.SUCCESS,
        //                    data = article_detail
        //                }); ;
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    status = (int)ResponseType.EMPTY,
        //                    msg = "data empty !!!"
        //                });
        //            }
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                status = (int)ResponseType.ERROR,
        //                msg = "Key ko hop le"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
        //        LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
        //        return Ok(new
        //        {
        //            status = (int)ResponseType.FAILED,
        //            msg = "Error: " + ex.ToString(),
        //        });
        //    }
        //}
    }
}
