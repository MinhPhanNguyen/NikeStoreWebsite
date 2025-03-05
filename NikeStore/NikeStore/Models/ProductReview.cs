using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikeStore.Models
{
    public class ProductReview
    {
        [Key]

        public int Id { get; set; }
        public long ProductId { get; set; }
        [Required(ErrorMessage = "Vui long nhap binh luan")]
        public string Review { get; set; }
        [Required(ErrorMessage = "Vui long chon danh gia")]
        public int Rating { get; set; }
        public string Reviewer { get; set; }
        public string ReviewerEmail { get; set; }
        public DateTime CreatedAt { get; set; } = System.DateTime.Now;

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
