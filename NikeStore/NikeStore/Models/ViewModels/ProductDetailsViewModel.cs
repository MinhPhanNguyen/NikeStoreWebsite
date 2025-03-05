using System.ComponentModel.DataAnnotations;

namespace NikeStore.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập bình luận")]
        public string Review { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn đánh giá")]
        public int Rating { get; set; }
    }
}
