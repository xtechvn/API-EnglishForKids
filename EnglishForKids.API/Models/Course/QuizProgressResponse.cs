namespace HuloToys_Service.Models.Course
{
    public class QuizProgressResponse
    {
        public int Status { get; set; }   // Trạng thái request
        public bool Completed { get; set; } // Người dùng đã hoàn thành quiz chưa
        public int? NextQuestionIndex { get; set; } // Câu hỏi tiếp theo cần làm (null nếu hoàn thành)
        public int CorrectCount { get; set; } // Số câu đúng
        public List<QuestionModel> CorrectAnswers { get; set; } = new List<QuestionModel>();
        public List<QuestionModel> IncorrectAnswers { get; set; } = new List<QuestionModel>();
        public string Message { get; set; } // Thông báo trạng thái
    }

    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
    }

    public class AnswerModel
    {
        public int AnswerId { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public string Note { get; set; }
    }
}
