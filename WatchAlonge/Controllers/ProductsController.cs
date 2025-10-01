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
            // I want to get all the categories from the database and pass it to the view
            // so I can put them in a dropdown list
            // so in the view I will do this ---> <select asp-for="category" class="form-control" asp-items="new SelectList(ViewBag.Categories)"></select>
            // To get all the categories from the database we will use a varible called ViewBag
            // ViewBag is a dynamic object that allows you to pass data from the controller to the view

            // .slect is a method that allows you to select a specific feiled from a data model 
            // c is just a variable name , c.Name means we are selecting the Name feiled from the Categories table
            // toList() is a method that converts the result to a list
            ViewBag.Categories = _context.Categories.Select(c => c.Name).ToList();
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
            ViewBag.Categories = _context.Categories.Select(c => c.Name).ToList();
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
