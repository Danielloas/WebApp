using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Identity;

namespace WebApp.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly CarShopContext _context;

        public ApplicationsController(CarShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cars = _context.Cars.ToList();
            if (cars.Count == 0)
            {
                ViewBag.Massage = "There are no cars available for sale.";
            }

            return View(cars);
        }

        [HttpPost]
        public IActionResult CreateTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var cars = _context.Cars.ToList();
            return View("Index", cars);
        }
    }
}