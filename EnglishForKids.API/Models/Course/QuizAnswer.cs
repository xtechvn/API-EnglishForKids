namespace HuloToys_Service.Models.Course
{
    public class QuizAnswer
    {
        public int Id { get; set; }

        public int QuizId { get; set; } // Quiz mà câu trả lời thuộc về

        public string Description { get; set; } // Nội dung câu trả lời

        public int? Order { get; set; } // Thứ tự hiển thị

        public string? Thumbnail { get; set; } // Ảnh minh họa (nếu có)

        public int Status { get; set; } // Trạng thái câu trả lời

        public bool IsCorrectAnswer { get; set; } // Đánh dấu đây là đáp án đúng

        public string? Note { get; set; } // Lời giải thích nếu đáp án sai

        public int CreatedBy { get; set; } // Người tạo câu trả lời

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
