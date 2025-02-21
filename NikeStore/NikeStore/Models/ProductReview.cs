using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikeStore.Models
{
    public class ProductReview
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public required string UserName { get; set; } // HoangThiHoa
        public required string ImgUrl { get; set; } // HoangThiHoa

        [Required]
        public int ProductId { get; set; } // Liên kết đến sản phẩm

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public DateTime ReviewDate { get; set; } // Ngày đánh giá

        [Range(1, 5)]
        public int Rating { get; set; } // Số sao

        public string? Comment { get; set; } // Bình luận nếu có
    }
}
