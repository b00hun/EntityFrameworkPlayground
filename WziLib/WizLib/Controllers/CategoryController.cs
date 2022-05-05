using Microsoft.AspNetCore.Mvc;
using WizLib_DataAcces.Data;
using WizLib_Models.Models;

namespace WizLib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> model = _db.Categories.ToList();
            return View(model);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new Category();
            if(id == null)
            {
                return View(obj);
            }
            
            obj = _db.Categories.FirstOrDefault(u=>u.Category_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Category_Id==0)
                {
                    //creating data
                    _db.Categories.Add(obj);
                }
                else
                {
                    //updating data
                    _db.Categories.Update(obj); 
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Category_Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
