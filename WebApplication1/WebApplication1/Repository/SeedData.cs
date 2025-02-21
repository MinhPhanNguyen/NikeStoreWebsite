using System.Linq;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace WebApplication1.Repository
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext _context)
        {
            _context.Database.Migrate();
            if (!_context.ProductCategory.Any())
            {
                _context.ProductCategory.AddRange(
                    new ProductCategory
                    {
                        CategoryName = "Air Force 1",
                        Slug = "airforce1",
                        Description = "Bộ sưu tập Air Force 1",
                        ImgUrl = "/images/Section3/1.png"
                    },
                    new ProductCategory
                    {
                        CategoryName = "Air Jordan 1",
                        Slug = "airjordan1",
                        Description = "Bộ sưu tập Air Jordan 1",
                        ImgUrl = "/images/Section3/1.png"
                    },
                    new ProductCategory
                    {
                        CategoryName = "Dunk",
                        Slug = "dunk",
                        Description = "Bộ sưu tập Dunk",
                        ImgUrl = "/images/Section3/1.png",
                    },
                    new ProductCategory
                    {
                        CategoryName = "Blazer",
                        Slug = "blazer",
                        Description = "Bộ sưu tập Blazer",
                        ImgUrl = "/images/Section3/1.png"
                    },
                    new ProductCategory
                    {
                        CategoryName = "Pegasus",
                        Slug = "pegasus",
                        Description = "Bộ sưu tập Pegasus",
                        ImgUrl = "/images/Section3/1.png"
                    }
                );
                _context.SaveChanges(); // Save categories to ensure IDs are generated
            }

            // Retrieve category IDs after saving them
            var airForceCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Air Force 1");
            var jordanCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Air Jordan 1");
            var dunkCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Dunk");
            var blazer = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Blazer");
            var pegasus = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Pegasus");
            // Add Products if they don't exist
            if (!_context.Product.Any())
            {
                var airForce1 = new Product
                {
                    Name = "Nike Air Force 1",
                    Slug = "airforce1",
                    Description = "💖 SHOP CAM KẾT: <br />\r\n\t\t\t\t\t✔ Cam kết chất lượng, hoàn tiền 100% khi không hài lòng về sản phẩm. <br />\r\n\t\t\t\t\t✔ Bao check/test đổi trả 30 ngày (sản phẩm còn nguyên tem, chưa qua sử dụng). <br />\r\n\t\t\t\t\t✔ Đa dạng mẫu mã, giá SALE RẺ nhất thị trường. <br />\r\n\t\t\t\t\t✔ Giao hàng nhanh đúng tiến độ không phải để quý khách chờ đợi lâu. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖Thông Tin sản phẩm: <br />\r\n\t\t\t\t\t- MÃ SẢN PHẨM: 314192-117 <br />\r\n\t\t\t\t\t- Chất Liệu Upper: Da PU Cao Cấp <br />\r\n\t\t\t\t\t- Chất Liệu Đế: Cao Su <br />\r\n\t\t\t\t\t- Kiểu Dáng : Cổ Thấp ( Low) <br />\r\n\t\t\t\t\t- Tình Trạng: Mới 100% Fullbox <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t3 LÝ DO KHIẾN AF1 ALL WHITE LUÔN HOT TỘT ĐỘ: <br />\r\n\t\t\t\t\t👉 Tính ứng dụng cao. <br />\r\n\t\t\t\t\tDù bạn là nam hay nữ ở bất kì độ tuổi nao thì AF1 Low White vẫn sẽ phát huy được tác dụng của mình. Bạn có thể đơn giản mặc mọi bộ đồ bạn yêu thích với AF1. <br />\r\n\t\t\t\t\t👉 Công nghệ air đệm khí. <br />\r\n\t\t\t\t\tMột lý do khiến các bạn trẻ lựa chọn mẫu Sneaker này đơn giản vì nó đi siêu êm chân. Nhờ công nghệ Air đặc biệt, bạn có thể hoạt động cả ngày vẫn có thể cảm nhận được sự thông thoáng và thoải mái. <br />\r\n\t\t\t\t\t👉 Thiết kế - phối màu. <br />\r\n\t\t\t\t\tChúng ta ai cũng phải công nhận thiết kế của AF1 là quá đẹp đi, nó vừa đơn giản tinh tế mà lại trông rất cá tính. Chưa kể một đôi giày trắng luôn là món đồ cần thiết trong tủ giày của mội người. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖CÁC TRƯỜNG HỢP ÁP DỤNG BẢO HÀNH TẠI OXO FASHION\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔ Shop cho đổi lại hàng khác trong vòng 7 ngày kể từ ngày mua. <br />\r\n\t\t\t\t\t✔ Sản phẩm giao sai về số lượng, sai thông tin và mẫu mã so với đơn đặt hàng khách đặt. <br />\r\n\t\t\t\t\t✔  Sản phẩm bị hỏng do lỗi nhà sản xuất (lỗi về thiết kế, chất liệu da hoặc vải bị rách hoặc bị bong tróc, khác biệt so với hình ảnh đăng tải trên website hoặc lỗi trong quá trình vận chuyển (bị biến dạng, trầy xước, vấy bẩn, nứt vỡ ...)\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔  Khách hàng mua không vừa kích cỡ (size) sẽ được đổi size. <br />\r\n\t\t\t\t\t✔  Sản phẩm mới 100% và chưa qua sử dụng. <br />",
                    Price = 200,
                    StockQuantity = 100,
                    CategoryID = airForceCategory.CategoryID, // Set CategoryID dynamically
                    IsHot = true,
                    IsFavorite = true,
                    ImageUrl = "/images/Section4/AIR FORCE 1 07.jpg",
                };

                var airJordan1 = new Product
                {
                    Name = "Nike Air Jordan 1",
                    Slug = "airjordan1",
                    Description = "💖 SHOP CAM KẾT22222: <br />\r\n\t\t\t\t\t✔ Cam kết chất lượng, hoàn tiền 100% khi không hài lòng về sản phẩm. <br />\r\n\t\t\t\t\t✔ Bao check/test đổi trả 30 ngày (sản phẩm còn nguyên tem, chưa qua sử dụng). <br />\r\n\t\t\t\t\t✔ Đa dạng mẫu mã, giá SALE RẺ nhất thị trường. <br />\r\n\t\t\t\t\t✔ Giao hàng nhanh đúng tiến độ không phải để quý khách chờ đợi lâu. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖Thông Tin sản phẩm: <br />\r\n\t\t\t\t\t- MÃ SẢN PHẨM: 314192-117 <br />\r\n\t\t\t\t\t- Chất Liệu Upper: Da PU Cao Cấp <br />\r\n\t\t\t\t\t- Chất Liệu Đế: Cao Su <br />\r\n\t\t\t\t\t- Kiểu Dáng : Cổ Thấp ( Low) <br />\r\n\t\t\t\t\t- Tình Trạng: Mới 100% Fullbox <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t3 LÝ DO KHIẾN AF1 ALL WHITE LUÔN HOT TỘT ĐỘ: <br />\r\n\t\t\t\t\t👉 Tính ứng dụng cao. <br />\r\n\t\t\t\t\tDù bạn là nam hay nữ ở bất kì độ tuổi nao thì AF1 Low White vẫn sẽ phát huy được tác dụng của mình. Bạn có thể đơn giản mặc mọi bộ đồ bạn yêu thích với AF1. <br />\r\n\t\t\t\t\t👉 Công nghệ air đệm khí. <br />\r\n\t\t\t\t\tMột lý do khiến các bạn trẻ lựa chọn mẫu Sneaker này đơn giản vì nó đi siêu êm chân. Nhờ công nghệ Air đặc biệt, bạn có thể hoạt động cả ngày vẫn có thể cảm nhận được sự thông thoáng và thoải mái. <br />\r\n\t\t\t\t\t👉 Thiết kế - phối màu. <br />\r\n\t\t\t\t\tChúng ta ai cũng phải công nhận thiết kế của AF1 là quá đẹp đi, nó vừa đơn giản tinh tế mà lại trông rất cá tính. Chưa kể một đôi giày trắng luôn là món đồ cần thiết trong tủ giày của mội người. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖CÁC TRƯỜNG HỢP ÁP DỤNG BẢO HÀNH TẠI OXO FASHION\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔ Shop cho đổi lại hàng khác trong vòng 7 ngày kể từ ngày mua. <br />\r\n\t\t\t\t\t✔ Sản phẩm giao sai về số lượng, sai thông tin và mẫu mã so với đơn đặt hàng khách đặt. <br />\r\n\t\t\t\t\t✔  Sản phẩm bị hỏng do lỗi nhà sản xuất (lỗi về thiết kế, chất liệu da hoặc vải bị rách hoặc bị bong tróc, khác biệt so với hình ảnh đăng tải trên website hoặc lỗi trong quá trình vận chuyển (bị biến dạng, trầy xước, vấy bẩn, nứt vỡ ...)\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔  Khách hàng mua không vừa kích cỡ (size) sẽ được đổi size. <br />\r\n\t\t\t\t\t✔  Sản phẩm mới 100% và chưa qua sử dụng. <br />",
                    Price = 150,
                    StockQuantity = 50,
                    CategoryID = jordanCategory.CategoryID, // Set CategoryID dynamically
                    IsHot = true,
                    IsFavorite = true,
                    ImageUrl = "/images/Section4/W AIR MAX DN ISA.jpg",
                };

                var dunk = new Product
                {
                    Name = "Nike Dunk",
                    Slug = "dunk",
                    Description = "💖 SHOP CAM KẾT3333: <br />\r\n\t\t\t\t\t✔ Cam kết chất lượng, hoàn tiền 100% khi không hài lòng về sản phẩm. <br />\r\n\t\t\t\t\t✔ Bao check/test đổi trả 30 ngày (sản phẩm còn nguyên tem, chưa qua sử dụng). <br />\r\n\t\t\t\t\t✔ Đa dạng mẫu mã, giá SALE RẺ nhất thị trường. <br />\r\n\t\t\t\t\t✔ Giao hàng nhanh đúng tiến độ không phải để quý khách chờ đợi lâu. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖Thông Tin sản phẩm: <br />\r\n\t\t\t\t\t- MÃ SẢN PHẨM: 314192-117 <br />\r\n\t\t\t\t\t- Chất Liệu Upper: Da PU Cao Cấp <br />\r\n\t\t\t\t\t- Chất Liệu Đế: Cao Su <br />\r\n\t\t\t\t\t- Kiểu Dáng : Cổ Thấp ( Low) <br />\r\n\t\t\t\t\t- Tình Trạng: Mới 100% Fullbox <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t3 LÝ DO KHIẾN AF1 ALL WHITE LUÔN HOT TỘT ĐỘ: <br />\r\n\t\t\t\t\t👉 Tính ứng dụng cao. <br />\r\n\t\t\t\t\tDù bạn là nam hay nữ ở bất kì độ tuổi nao thì AF1 Low White vẫn sẽ phát huy được tác dụng của mình. Bạn có thể đơn giản mặc mọi bộ đồ bạn yêu thích với AF1. <br />\r\n\t\t\t\t\t👉 Công nghệ air đệm khí. <br />\r\n\t\t\t\t\tMột lý do khiến các bạn trẻ lựa chọn mẫu Sneaker này đơn giản vì nó đi siêu êm chân. Nhờ công nghệ Air đặc biệt, bạn có thể hoạt động cả ngày vẫn có thể cảm nhận được sự thông thoáng và thoải mái. <br />\r\n\t\t\t\t\t👉 Thiết kế - phối màu. <br />\r\n\t\t\t\t\tChúng ta ai cũng phải công nhận thiết kế của AF1 là quá đẹp đi, nó vừa đơn giản tinh tế mà lại trông rất cá tính. Chưa kể một đôi giày trắng luôn là món đồ cần thiết trong tủ giày của mội người. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖CÁC TRƯỜNG HỢP ÁP DỤNG BẢO HÀNH TẠI OXO FASHION\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔ Shop cho đổi lại hàng khác trong vòng 7 ngày kể từ ngày mua. <br />\r\n\t\t\t\t\t✔ Sản phẩm giao sai về số lượng, sai thông tin và mẫu mã so với đơn đặt hàng khách đặt. <br />\r\n\t\t\t\t\t✔  Sản phẩm bị hỏng do lỗi nhà sản xuất (lỗi về thiết kế, chất liệu da hoặc vải bị rách hoặc bị bong tróc, khác biệt so với hình ảnh đăng tải trên website hoặc lỗi trong quá trình vận chuyển (bị biến dạng, trầy xước, vấy bẩn, nứt vỡ ...)\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔  Khách hàng mua không vừa kích cỡ (size) sẽ được đổi size. <br />\r\n\t\t\t\t\t✔  Sản phẩm mới 100% và chưa qua sử dụng. <br />",
                    Price = 180,
                    StockQuantity = 80,
                    CategoryID = dunkCategory.CategoryID, // Set CategoryID dynamically
                    IsHot = false,
                    IsFavorite = true,
                    ImageUrl = "/images/Section4/W NIKE DUNK LOW NEXT NATURE.jpg",
                };
                _context.Product.AddRange(airForce1, airJordan1, dunk);
                _context.SaveChanges();
            }
        }
    }
}
