using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NikeStore.Models;
using NikeStore.Models.ViewModels;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly DataContext _context;

        public CheckOutController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CheckOut()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if(userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var orderCode = Guid.NewGuid().ToString();
                var orderItem = new Order();
                orderItem.OrderCode = orderCode;
                orderItem.Status = 1;
                orderItem.UserName = userEmail;
                orderItem.CreateDate = DateTime.Now;
                _context.Add(orderItem);
                _context.SaveChanges();
                List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderItem.UserName = userEmail;
                    orderDetail.OrderCode = orderCode;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.Price = item.Price;
                    _context.Add(orderDetail);
                    _context.SaveChanges();
                }
                HttpContext.Session.Remove("Cart");
                TempData["success"] = "Order has been created successfully!";
                return RedirectToAction("Index", "Cart");
            }
            return View();
        }
    }
}
