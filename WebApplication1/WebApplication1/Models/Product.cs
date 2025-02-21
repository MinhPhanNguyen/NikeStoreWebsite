using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required, StringLength(150, MinimumLength = 3, ErrorMessage = "Tên sản phẩm phải từ 3 đến 150 ký tự.")]
        public required string Name { get; set; }

        public required string Slug { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required(ErrorMessage = "Mô tả không được để trống.")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000, ErrorMessage = "Giá sản phẩm phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn kho không thể âm.")]
        public int StockQuantity { get; set; }


        [Required(ErrorMessage = "Danh mục là bắt buộc.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Màu sắc là bắt buộc.")]
        public int ProductColorID { get; set; }

        [Required(ErrorMessage = "Kích thước là bắt buộc.")]
        public int ProductSizeID { get; set; }

        [Required(ErrorMessage = "Loại là bắt buộc.")]
        public int ProductTypeID { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc.")]
        public int GenderID { get; set; }

        public bool IsHot { get; set; } = false;

        public bool IsFavorite { get; set; } = false;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("CategoryID")]
        public ProductCategory ProductCategory { get; set; }

        [Url(ErrorMessage = "Đường dẫn sản phẩm không hợp lệ.")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        [FileExtensions]
        [Required(ErrorMessage = "Anh là bắt buộc.")]
        public IFormFile ImageUpload { get; set; }
    }
}
