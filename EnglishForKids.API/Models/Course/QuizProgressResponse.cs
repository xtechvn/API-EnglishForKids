namespace HuloToys_Service.Models.Course
{
    public class QuizProgressResponse
    {
        public int Status { get; set; }   // Trạng thái request
        public bool Completed { get; set; } // Người dùng đã hoàn thành quiz chưa
        public int? NextQuestionIndex { get; set; } // Câu hỏi tiếp theo cần làm (null nếu hoàn thành)
        public int CorrectCount { get; set; } // Số câu đúng
        public List<QuestionModel> CorrectAnswers { get; set; } = new List<QuestionModel>(); // ✅ Danh sách câu trả lời đúng
        public List<QuestionModel> SkippedQuestions { get; set; } = new List<QuestionModel>(); // ✅ Danh sách câu bị bỏ qua
        public List<QuestionModel> IncorrectAnswers { get; set; } = new List<QuestionModel>(); // ✅ Danh sách câu trả lời sai
        public List<QuestionModel> AllQuestions { get; set; } = new List<QuestionModel>(); // ✅ Toàn bộ danh sách câu hỏi (mới thêm)
        public string Message { get; set; } // Thông báo trạng thái
    }

    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
        public bool IsAnswered { get; set; } // ✅ Mới thêm: Kiểm tra câu hỏi đã làm chưa
        public int? SelectedAnswer { get; set; } // ✅ Mới thêm: Lưu câu trả lời đã chọn (nếu có)
    }

    public class AnswerModel
    {
        public int AnswerId { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public string Note { get; set; }
    }
}
