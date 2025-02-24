using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikeStore.Repository;

namespace NikeStore.Controllers
{
    public class ServiceController : Controller
    {
        private readonly DataContext _context;
        public ServiceController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AuthAccessories(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> AuthShoe(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> Caring(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> MeetingDetail(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> MovingSupport(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> Repairing(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> Service(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }

        public async Task<IActionResult> SupportHotline(int Id)
        {
            if (Id == null) return RedirectToAction("Index", "Home");
            var service = _context.Service
                .AsNoTracking()
                .Include(p => p.ServiceTypes)
                .FirstOrDefault(p => p.ServiceID == Id);
            return View(service);
        }
    }
}
