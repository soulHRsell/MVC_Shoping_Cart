using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Shoping_Card.Models;
using Shoping_Card_DB_Connection.DataAccess;
using Shoping_Card_DB_Connection.Models;
using System.Security.Claims;

namespace MVC_Shoping_Card.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ISqlData _db;

        public CategoryController(ISqlData db)
        {
            _db = db;
        }

        // GET: CategoryController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var categories = _db.GetAllCategories();
            List<CategoryViewModel> categoriesView = new List<CategoryViewModel>();
            for (int i = 0; i < categories.Count; i++)
            {
                CategoryViewModel cat = new CategoryViewModel()
                {
                    Id = categories[i].Id,
                    Name = categories[i].Name,  
                };
                categoriesView.Add(cat); 
            }
            return View(categoriesView);
        }

        // GET: CategoryController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryCreateModel cat = new CategoryCreateModel();
                cat.AdminId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                cat.Name = model.Name;
                _db.CreateCategory(cat);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var category = _db.GetCategoryById(id).FirstOrDefault();
            CategoryViewModel categoryView = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,   
            };
            
            return View(categoryView);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CategoryViewModel model, IFormCollection collection)
        {
            if(ModelState.IsValid)
            {
                CategoryModel category = new CategoryModel()
                {
                    Id = model.Id,  
                    Name = model.Name,  
                };

                _db.EditCategory(category);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
                
        }

        // GET: CategoryController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var category = _db.GetCategoryById(id).FirstOrDefault(); 
            CategoryViewModel categoryview = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name    
            };   

            return View(categoryview);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = _db.GetCategoryById(id).FirstOrDefault();

            if(category == null)
            {
                return NotFound();
            }
           
            _db.DeleteCategory(category.Id);
            return RedirectToAction(nameof(Index));
            

        }
    }
}
