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
        public CourseController(IConfiguration config, RedisConn redisService)
        {
            configuration = config;

            _redisService = redisService;
            _redisService = new RedisConn(config);
            _redisService.Connect();
            _courseBusiness = new CourseBusiness(configuration);

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
