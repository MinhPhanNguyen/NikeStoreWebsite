using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NikeStore.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required, StringLength(150, MinimumLength = 3, ErrorMessage = "Tên dịch vụ phải từ 3 đến 150 ký tự.")]
        public required string Name { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Một Service có nhiều ServiceType
        public virtual ICollection<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();
    }
}
