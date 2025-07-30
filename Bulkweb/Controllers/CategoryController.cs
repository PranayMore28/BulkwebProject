using Bulkweb.Data;
using Bulkweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext  _db;
         
        public CategoryController (ApplicationDbContext db)
        {
            _db = db;
        }        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("name","The Display order cannot br match the name");
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromBb = _db.Categories.Find(id);
            //Category? CategoryFromdb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? CategoryFromdb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (CategoryFromBb == null)
            {
                return NotFound();
            }
            return View(CategoryFromBb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromBb = _db.Categories.Find(id);
            //Category? CategoryFromdb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? CategoryFromdb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (CategoryFromBb == null)
            {
                return NotFound();
            }
            return View(CategoryFromBb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult Deletepost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index", "Category");
           
        }
    }
}
