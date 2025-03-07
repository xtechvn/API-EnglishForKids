namespace HuloToys_Service.Models.Course
{
    public class QuizResult
    {
        public int Id { get; set; }

        public int SourceId { get; set; } // Khóa học của bài quiz

        public int QuizId { get; set; } // ID bài quiz

        public int QuizAnswerId { get; set; } // Đáp án mà user chọn

        public int UserId { get; set; } // Người dùng thực hiện quiz

        public int CreatedBy { get; set; } // Người tạo kết quả

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
