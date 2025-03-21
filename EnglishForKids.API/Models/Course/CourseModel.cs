using Nest;

namespace HuloToys_Service.Models.Course
{
    public class CourseModel
    {
        [PropertyName("id")]
        public int id { get; set; }

        [PropertyName("Title")]
        public string title { get; set; }

        [PropertyName("Description")]
        public string description { get; set; }

        [PropertyName("Thumbnail")]
        public string thumbnail { get; set; }
        [PropertyName("Status")]
        public int status { get; set; }
        [PropertyName("Benefif")]
        public string benefif { get; set; }
       

        [PropertyName("VideoIntro")]
        public string video_intro { get; set; }

        [PropertyName("CreatedDate")]
        public DateTime? created_date { get; set; }
        [PropertyName("PublishDate")]
        public DateTime? publish_date { get; set; }

        [PropertyName("Price")]
        public decimal price { get; set; }

        [PropertyName("OriginalPrice")]
        public decimal original_price { get; set; }

        [PropertyName("ListCategoryId")]
        public string list_category_id { get; set; }

        [PropertyName("ListCategoryName")]
        public string list_category_name { get; set; }
        // ✅ Thêm tổng số bài giảng
        [PropertyName("TotalLessons")]
        public int TotalLessons { get; set; }

        // ✅ Thêm tổng thời lượng khóa học (phút)
        [PropertyName("TotalDuration")]
        public int TotalDuration { get; set; }
    }
}
