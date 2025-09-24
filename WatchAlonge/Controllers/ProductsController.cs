using Microsoft.AspNetCore.Mvc;
using WatchAlonge.Data;
using WatchAlonge.Models;

namespace WatchAlonge.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context; 

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<Products> products = _context.Products.ToList();
            return View(products);
        }
        [HttpGet]   
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Products products)
            {
            _context.Products.Add(products);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var products = _context.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        public IActionResult Edit(Products products)
        {
            _context.Products.Update(products);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var products = _context.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        [HttpPost]
        public IActionResult Delete(Products products)
        {

            _context.Products.Remove(products);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
