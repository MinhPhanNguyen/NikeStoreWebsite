using System.Linq;
using NikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace NikeStore.Repository
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext _context)
        {
            _context.Database.Migrate();

            // Add Product Categories (Collections) if they don't exist
            if (!_context.Warehouse.Any()) // Kiểm tra xem có dữ liệu chưa
            {
                _context.Warehouse.AddRange(
                    new Warehouse
                    {
                        WarehouseName = "Main Warehouse",
                        Location = "Hanoi, Vietnam",
                        Capacity = 10000,
                        CreatedAt = DateTime.Now
                    },
                    new Warehouse
                    {
                        WarehouseName = "Backup Warehouse",
                        Location = "Ho Chi Minh, Vietnam",
                        Capacity = 5000,
                        CreatedAt = DateTime.Now
                    }
                );
                _context.SaveChanges(); // Lưu dữ liệu vào DB
            }

            // Add Product Categories (Collections) if they don't exist
            if (!_context.Provider.Any()) // Kiểm tra xem có dữ liệu chưa
            {
                _context.Provider.AddRange(
                   new Provider
                   {
                       ProviderName = "Nike Supplier",
                       ContactPerson = "John Doe",
                       Phone = "0123456789",
                       Email = "supplier@nike.com",
                       Address = "USA",
                       CreatedAt = DateTime.Now
                   },
                    new Provider
                    {
                        ProviderName = "Adidas Supplier",
                        ContactPerson = "Jane Smith",
                        Phone = "0987654321",
                        Email = "supplier@adidas.com",
                        Address = "Germany",
                        CreatedAt = DateTime.Now
                    }
                );
                _context.SaveChanges(); // Lưu dữ liệu vào DB
            }

            // Add Product Categories (Collections) if they don't exist
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
                        ImgUrl = "/images/Section3/2.png"
                    },
                     new ProductCategory
                     {
                         CategoryName = "Air Max",
                         Slug = "airmax",
                         Description = "Bộ sưu tập Air Max",
                         ImgUrl = "/images/Section3/3.png"
                     },
                    new ProductCategory
                    {
                        CategoryName = "Dunk",
                        Slug = "dunk",
                        Description = "Bộ sưu tập Dunk",
                        ImgUrl = "/images/Section3/4.png",
                    },
                    new ProductCategory
                    {
                        CategoryName = "Blazer",
                        Slug = "blazer",
                        Description = "Bộ sưu tập Blazer",
                        ImgUrl = "/images/Section3/5.png"
                    },
                    new ProductCategory
                    {
                        CategoryName = "Pegasus",
                        Slug = "pegasus",
                        Description = "Bộ sưu tập Pegasus",
                        ImgUrl = "/images/Section3/6.png"
                    }
                );
                _context.SaveChanges(); // Save categories to ensure IDs are generated
            }

            // Retrieve category IDs after saving them
            var airForceCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Air Force 1");
            var jordanCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Air Jordan 1");
            var maxCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Air Max");
            var dunkCategory = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Dunk");
            var blazer = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Blazer");
            var pegasus = _context.ProductCategory.FirstOrDefault(c => c.CategoryName == "Pegasus");

            if (!_context.Service.Any())
            {
                _context.Service.AddRange(
                    new Service { Name = "DỊCH VỤ SAU BÁN HÀNG", Description = "Các dịch vụ hỗ trợ sau khi mua hàng.", ImageUrl = "/images/Section6/1.png" },
                    new Service { Name = "GIÀY VÀ PHỤ KIỆN", Description = "Các dịch vụ hỗ trợ sau khi mua hàng.", ImageUrl = "/images/Section6/2.png" },
                    new Service { Name = "HỖ TRỢ KHÁCH HÀNG", Description = "Các dịch vụ hỗ trợ sau khi mua hàng.", ImageUrl = "/images/Section6/3.png" },
                    new Service { Name = "ĐẶT LỊCH HẸN", Description = "Các dịch vụ hỗ trợ sau khi mua hàng.", ImageUrl = "/images/Section6/4.png" }
                );
                _context.SaveChanges(); // Save categories to ensure IDs are generated
            }

            if (!_context.ServiceType.Any())
            {
                _context.ServiceType.AddRange(
                    new ServiceType { Name = "Chính sách bảo hành", Description = "Chính sách bảo hành chính hãng.", ServiceID = 1, Link = "/Service/Index" },
                    new ServiceType { Name = "Dịch vụ sửa chữa", Description = "Chính sách bảo hành chính hãng.", ServiceID = 1, Link = "/Repairing/Index" },
                    new ServiceType { Name = "Dịch vụ chăm sóc giày", Description = "Dịch vụ chăm sóc giày", ServiceID = 1, Link = "/Caring/Index" },
                    new ServiceType { Name = "Giày chính hãng", Description = "Dịch vụ sửa chữa giày chính hãng.", ServiceID = 2, Link = "/AuthShoe/Index" },
                    new ServiceType { Name = "Phụ kiện chính hãng", Description = "Dịch vụ sửa chữa giày chính hãng.", ServiceID = 2, Link = "/AuthAccessories/Index" },
                    new ServiceType { Name = "Tổng đài chăm sóc khách hàng", Description = "Chăm sóc và vệ sinh giày.", ServiceID = 3, Link = "/MovingSupport/Index" },
                    new ServiceType { Name = "Chăm sóc khách hàng di động", Description = "Chăm sóc và vệ sinh giày.", ServiceID = 3, Link = "/SupportHotline/Index" },
                    new ServiceType { Name = "Xem chi tiết", Description = "Chăm sóc và vệ sinh giày.", ServiceID = 4, Link = "/MeetingDetail/Index" }
                );
                _context.SaveChanges(); // Save categories to ensure IDs are generated
            }

            if (!_context.ProductColor.Any())
            {
                _context.ProductColor.AddRange(
                    new ProductColor { Color = "Red" },
                    new ProductColor { Color = "Blue" },
                    new ProductColor { Color = "Green" },
                    new ProductColor { Color = "Black" },
                    new ProductColor { Color = "White" }
                );
                _context.SaveChanges();
            }

            // Retrieve category IDs after saving them
            var Red = _context.ProductColor.FirstOrDefault(c => c.Color == "Red");
            var Blue = _context.ProductColor.FirstOrDefault(c => c.Color == "Blue");
            var Green = _context.ProductColor.FirstOrDefault(c => c.Color == "Green");
            var Black = _context.ProductColor.FirstOrDefault(c => c.Color == "Black");
            var White = _context.ProductColor.FirstOrDefault(c => c.Color == "White");

            // Add Product Genders if they don't exist
            if (!_context.ProductGender.Any())
            {
                _context.ProductGender.AddRange(
                    new ProductGender { GenderName = "Men" },
                    new ProductGender { GenderName = "Women" },
                    new ProductGender { GenderName = "Unisex" }
                );
                _context.SaveChanges();
            }

            // Retrieve category IDs after saving them
            var Men = _context.ProductGender.FirstOrDefault(c => c.GenderName == "Men");
            var Women = _context.ProductGender.FirstOrDefault(c => c.GenderName == "Women");
            var Unisex = _context.ProductGender.FirstOrDefault(c => c.GenderName == "Unisex");

            // Add Product Sizes if they don't exist
            if (!_context.ProductSize.Any())
            {
                _context.ProductSize.AddRange(
                    new ProductSize { Size = "40" },
                    new ProductSize { Size = "41" },
                    new ProductSize { Size = "42" },
                    new ProductSize { Size = "43" },
                    new ProductSize { Size = "44" }
                );
                _context.SaveChanges();
            }

            // Retrieve category IDs after saving them
            var size40 = _context.ProductSize.FirstOrDefault(c => c.Size == "40");
            var size41 = _context.ProductSize.FirstOrDefault(c => c.Size == "41");
            var size42 = _context.ProductSize.FirstOrDefault(c => c.Size == "42");
            var size43 = _context.ProductSize.FirstOrDefault(c => c.Size == "43");
            var size44 = _context.ProductSize.FirstOrDefault(c => c.Size == "44");

            // Add Product Types if they don't exist
            if (!_context.ProductType.Any())
            {
                _context.ProductType.AddRange(
                    new ProductType { Type = "High" },
                    new ProductType { Type = "Low" },
                    new ProductType { Type = "Middle" }
                );
                _context.SaveChanges();
            }

            // Retrieve category IDs after saving them
            var High = _context.ProductType.FirstOrDefault(c => c.Type == "High");
            var Low = _context.ProductType.FirstOrDefault(c => c.Type == "Low");
            var Middle = _context.ProductType.FirstOrDefault(c => c.Type == "Middle");

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
                    CategoryID = airForceCategory.CategoryID, 
                    ProductColorID = White.ProductColorID, 
                    ProductSizeID = size41.ProductSizeID, 
                    ProductTypeID = Low.ProductTypeID, 
                    GenderID = Men.GenderID, 
                    WarehouseID = 1,
                    IsHot = true,
                    IsFavorite = true,
                    ImageUrl = "AIR FORCE 1 07.jpg",
                };

                var airJordan1 = new Product
                {
                    Name = "Nike Air Jordan 1",
                    Slug = "airjordan1",
                    Description = "💖 SHOP CAM KẾT22222: <br />\r\n\t\t\t\t\t✔ Cam kết chất lượng, hoàn tiền 100% khi không hài lòng về sản phẩm. <br />\r\n\t\t\t\t\t✔ Bao check/test đổi trả 30 ngày (sản phẩm còn nguyên tem, chưa qua sử dụng). <br />\r\n\t\t\t\t\t✔ Đa dạng mẫu mã, giá SALE RẺ nhất thị trường. <br />\r\n\t\t\t\t\t✔ Giao hàng nhanh đúng tiến độ không phải để quý khách chờ đợi lâu. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖Thông Tin sản phẩm: <br />\r\n\t\t\t\t\t- MÃ SẢN PHẨM: 314192-117 <br />\r\n\t\t\t\t\t- Chất Liệu Upper: Da PU Cao Cấp <br />\r\n\t\t\t\t\t- Chất Liệu Đế: Cao Su <br />\r\n\t\t\t\t\t- Kiểu Dáng : Cổ Thấp ( Low) <br />\r\n\t\t\t\t\t- Tình Trạng: Mới 100% Fullbox <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t3 LÝ DO KHIẾN AF1 ALL WHITE LUÔN HOT TỘT ĐỘ: <br />\r\n\t\t\t\t\t👉 Tính ứng dụng cao. <br />\r\n\t\t\t\t\tDù bạn là nam hay nữ ở bất kì độ tuổi nao thì AF1 Low White vẫn sẽ phát huy được tác dụng của mình. Bạn có thể đơn giản mặc mọi bộ đồ bạn yêu thích với AF1. <br />\r\n\t\t\t\t\t👉 Công nghệ air đệm khí. <br />\r\n\t\t\t\t\tMột lý do khiến các bạn trẻ lựa chọn mẫu Sneaker này đơn giản vì nó đi siêu êm chân. Nhờ công nghệ Air đặc biệt, bạn có thể hoạt động cả ngày vẫn có thể cảm nhận được sự thông thoáng và thoải mái. <br />\r\n\t\t\t\t\t👉 Thiết kế - phối màu. <br />\r\n\t\t\t\t\tChúng ta ai cũng phải công nhận thiết kế của AF1 là quá đẹp đi, nó vừa đơn giản tinh tế mà lại trông rất cá tính. Chưa kể một đôi giày trắng luôn là món đồ cần thiết trong tủ giày của mội người. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖CÁC TRƯỜNG HỢP ÁP DỤNG BẢO HÀNH TẠI OXO FASHION\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔ Shop cho đổi lại hàng khác trong vòng 7 ngày kể từ ngày mua. <br />\r\n\t\t\t\t\t✔ Sản phẩm giao sai về số lượng, sai thông tin và mẫu mã so với đơn đặt hàng khách đặt. <br />\r\n\t\t\t\t\t✔  Sản phẩm bị hỏng do lỗi nhà sản xuất (lỗi về thiết kế, chất liệu da hoặc vải bị rách hoặc bị bong tróc, khác biệt so với hình ảnh đăng tải trên website hoặc lỗi trong quá trình vận chuyển (bị biến dạng, trầy xước, vấy bẩn, nứt vỡ ...)\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔  Khách hàng mua không vừa kích cỡ (size) sẽ được đổi size. <br />\r\n\t\t\t\t\t✔  Sản phẩm mới 100% và chưa qua sử dụng. <br />",
                    Price = 150,
                    StockQuantity = 50,
                    CategoryID = jordanCategory.CategoryID, 
                    ProductColorID = Black.ProductColorID, 
                    ProductSizeID = size42.ProductSizeID, 
                    ProductTypeID = Middle.ProductTypeID, 
                    GenderID = Women.GenderID, 
                    WarehouseID = 2,
                    IsHot = true,
                    IsFavorite = true,
                    ImageUrl = "W AIR MAX DN ISA.jpg",
                };

                var dunk = new Product
                {
                    Name = "Nike Dunk",
                    Slug = "dunk",
                    Description = "💖 SHOP CAM KẾT3333: <br />\r\n\t\t\t\t\t✔ Cam kết chất lượng, hoàn tiền 100% khi không hài lòng về sản phẩm. <br />\r\n\t\t\t\t\t✔ Bao check/test đổi trả 30 ngày (sản phẩm còn nguyên tem, chưa qua sử dụng). <br />\r\n\t\t\t\t\t✔ Đa dạng mẫu mã, giá SALE RẺ nhất thị trường. <br />\r\n\t\t\t\t\t✔ Giao hàng nhanh đúng tiến độ không phải để quý khách chờ đợi lâu. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖Thông Tin sản phẩm: <br />\r\n\t\t\t\t\t- MÃ SẢN PHẨM: 314192-117 <br />\r\n\t\t\t\t\t- Chất Liệu Upper: Da PU Cao Cấp <br />\r\n\t\t\t\t\t- Chất Liệu Đế: Cao Su <br />\r\n\t\t\t\t\t- Kiểu Dáng : Cổ Thấp ( Low) <br />\r\n\t\t\t\t\t- Tình Trạng: Mới 100% Fullbox <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t3 LÝ DO KHIẾN AF1 ALL WHITE LUÔN HOT TỘT ĐỘ: <br />\r\n\t\t\t\t\t👉 Tính ứng dụng cao. <br />\r\n\t\t\t\t\tDù bạn là nam hay nữ ở bất kì độ tuổi nao thì AF1 Low White vẫn sẽ phát huy được tác dụng của mình. Bạn có thể đơn giản mặc mọi bộ đồ bạn yêu thích với AF1. <br />\r\n\t\t\t\t\t👉 Công nghệ air đệm khí. <br />\r\n\t\t\t\t\tMột lý do khiến các bạn trẻ lựa chọn mẫu Sneaker này đơn giản vì nó đi siêu êm chân. Nhờ công nghệ Air đặc biệt, bạn có thể hoạt động cả ngày vẫn có thể cảm nhận được sự thông thoáng và thoải mái. <br />\r\n\t\t\t\t\t👉 Thiết kế - phối màu. <br />\r\n\t\t\t\t\tChúng ta ai cũng phải công nhận thiết kế của AF1 là quá đẹp đi, nó vừa đơn giản tinh tế mà lại trông rất cá tính. Chưa kể một đôi giày trắng luôn là món đồ cần thiết trong tủ giày của mội người. <br />\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t💖CÁC TRƯỜNG HỢP ÁP DỤNG BẢO HÀNH TẠI OXO FASHION\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔ Shop cho đổi lại hàng khác trong vòng 7 ngày kể từ ngày mua. <br />\r\n\t\t\t\t\t✔ Sản phẩm giao sai về số lượng, sai thông tin và mẫu mã so với đơn đặt hàng khách đặt. <br />\r\n\t\t\t\t\t✔  Sản phẩm bị hỏng do lỗi nhà sản xuất (lỗi về thiết kế, chất liệu da hoặc vải bị rách hoặc bị bong tróc, khác biệt so với hình ảnh đăng tải trên website hoặc lỗi trong quá trình vận chuyển (bị biến dạng, trầy xước, vấy bẩn, nứt vỡ ...)\r\n\t\t\t\t\t<br />\r\n\t\t\t\t\t✔  Khách hàng mua không vừa kích cỡ (size) sẽ được đổi size. <br />\r\n\t\t\t\t\t✔  Sản phẩm mới 100% và chưa qua sử dụng. <br />",
                    Price = 180,
                    StockQuantity = 80,
                    CategoryID = dunkCategory.CategoryID, 
                    ProductColorID = Black.ProductColorID, 
                    ProductSizeID = size42.ProductSizeID, 
                    ProductTypeID = Middle.ProductTypeID, 
                    GenderID = Women.GenderID, 
                    WarehouseID = 2,
                    IsHot = false,
                    IsFavorite = true,
                    ImageUrl = "W NIKE DUNK LOW NEXT NATURE.jpg",
                };
                _context.Product.AddRange(airForce1, airJordan1, dunk);
                _context.SaveChanges();
            }

            // Add Product Categories (Collections) if they don't exist
            if (!_context.Importing.Any()) // Kiểm tra xem có dữ liệu chưa
            {
                _context.Importing.AddRange(
                   new Importing
                   {
                       ProviderID = 1,
                       WarehouseID = 1,
                       ImportDate = DateTime.Now,
                       TotalAmount = 30000.00m,
                       Status = "Completed"
                   },
                    new Importing
                    {
                        ProviderID = 2,
                        WarehouseID = 2,
                        ImportDate = DateTime.Now,
                        TotalAmount = 20000.00m,
                        Status = "Pending"
                    }
                );
                _context.SaveChanges(); // Lưu dữ liệu vào DB
            }
        }
    }
}
