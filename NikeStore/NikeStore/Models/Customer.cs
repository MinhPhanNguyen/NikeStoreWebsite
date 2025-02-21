using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NikeStore.Repository.Validation;

namespace NikeStore.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "Tên tài khoản phải từ 3 đến 100 ký tự.")]
        public required string CustomerName { get; set; }

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "Mật khẩu phải từ 3 đến 100 ký tự.")]
        public required string Password { get; set; }

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "Email phải từ 3 đến 100 ký tự.")]
        public required string Email { get; set; }

        [Required, StringLength(15, MinimumLength = 3, ErrorMessage = "Số điện thoại phải từ 3 đến 15 ký tự.")]
        public required string PhoneNumber { get; set; }

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "Địa chỉ phải từ 3 đến 100 ký tự.")]
        public required string Address { get; set; }

        public string ImgUrl { get; set; } = "noimage.jpg";

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
