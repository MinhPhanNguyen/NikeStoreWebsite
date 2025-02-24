﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Models;
using NikeStore.Repository;

namespace NikeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Order()
        {
            return View(await _context.Order.OrderByDescending(p => p.Id).ToListAsync());
        }

        public async Task<IActionResult> DoneOrder()
        {
            return View(await _context.Order.OrderByDescending(p => p.Id).Where(p => p.Status == 0).ToListAsync());
        }

        public async Task<IActionResult> WaitingOrder()
        {
            return View(await _context.Order.OrderByDescending(p => p.Id).Where(p => p.Status == 1).ToListAsync());
        }

        public async Task<IActionResult> ViewOrder(string orderCode)
        {
            var orderDetail = await _context.OrderDetail
                .Include(od => od.Product)
                .Include(od => od.Product.ProductType)
                .Include(od => od.Product.ProductColor)
                .Include(od => od.Product.ProductSize)
                .Where(od => od.OrderCode == orderCode)
                .ToListAsync();

            return View(orderDetail);
        }

        public async Task<IActionResult> Delete(string orderCode)
        {
            var order = await _context.Order.FirstOrDefaultAsync(o => o.OrderCode == orderCode);
            if (order == null)
            {
                TempData["error"] = "Không tìm thấy đơn hàng!";
                return RedirectToAction("Order");
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa đơn hàng thành công";
            return RedirectToAction("Order");
        }
    }
}
