using System.ComponentModel.DataAnnotations;

namespace HuloToys_Service.Models.Course
{
    public class Quiz
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int SourceId { get; set; } // Khóa học chứa bài quiz

        public int ChapterId { get; set; } // Chương của bài quiz

        public string? Description { get; set; }

        public int Order { get; set; } // Thứ tự hiển thị

        public string? Thumbnail { get; set; } // Ảnh minh họa

        public string Type { get; set; } // Loại quiz

        public int Status { get; set; } // Trạng thái quiz

        public int CreatedBy { get; set; } // Người tạo

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int IsDelete { get; set; } // Đánh dấu đã xóa

        public int? ParentId { get; set; } // Nếu là quiz con của quiz khác
    }
}
