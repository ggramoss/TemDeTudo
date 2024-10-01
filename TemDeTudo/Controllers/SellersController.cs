using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Data;
using TemDeTudo.Models;

namespace TemDeTudo.Controllers
{
    public class SellersController : Controller
    {
        private readonly TemDeTudoContext _context;

        public SellersController(TemDeTudoContext context){
            _context = context;
        }
        public IActionResult Index()
        {
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }

        public IActionResult Create() {


            
                
                return View();
        }
        [HttpPost]
        public IActionResult Create(Seller seller) {

            if (seller == null)
            {
                return NotFound();
            }
            seller.Department =_context.Department.FirstOrDefault();
            seller.DepartmentId = seller.Department.Id;

            _context.Seller.Add(seller);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
