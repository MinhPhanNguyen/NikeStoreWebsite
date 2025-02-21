using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NikeStore.Models
{
    public class ServiceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceTypeID { get; set; }

        [Required, StringLength(150, MinimumLength = 3, ErrorMessage = "Tên loại dịch vụ phải từ 3 đến 150 ký tự.")]
        public required string Name { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? Link { get; set; }

        // Khóa ngoại tham chiếu đến Service
        [ForeignKey("ServiceID")]
        public int ServiceID { get; set; }
        public virtual Service? Service { get; set; }
    }
}
