using Microsoft.AspNetCore.Mvc;
using WatchAlonge.Data;
using WatchAlonge.Models;

namespace WatchAlonge.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        // API to get all categories 
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return Ok(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        // in form submission page we have this ---> <form asp-action="Create" method="post">
        // so it will look for Create action method with HttpPost attribute
        // so the data will come here , then it binds to the Category object
        // then we add it to the database and save changes 
        // after that it will just return to the same view. 
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            // RedirectToAction() ---> you pass the view name here , and it will redirect to that view
            return RedirectToAction("Index");
        }

        // Edit category by id
        // from my index page i have this ---> <a asp-action="Edit" asp-route-id="@item.Id" class="btn btn-primary">Edit</a>
        // this is just a link to the Edit action method with id as route value
        // asp-route-id="@item.Id" --> this is inside my foreach loop so it will pass the id of the category to the Edit action method
        // so when the page opens it will call the Edit action method with the id and get the category from the database
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // after we open the Edit page and make changes to the category (with the ID we passed) . and then we click on the submit button
        // it will call the Edit action method with HttpPost attribute
        // it will come here with the updated category object , and update it in the database
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // Delete category by id
        // this follows the same pattern as Edit
        // in the get method we get the category by id and show it in the view
        // using this ---> <a asp-action="Delete" asp-route-id="@item.Id" class="btn btn-danger">Delete</a>
        // this a link is coming from my index page
        // the part with asp-route-id="@item.Id" is passing the id of the category to the Delete action method
        // in the view we show the category details and ask for confirmation to delete
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        // when the user confirms the deletion by clicking on the submit button
        // it will call the Delete action method with HttpPost attribute
        // it will come here with the category object to be deleted
        // then we remove it from the database and save changes
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
