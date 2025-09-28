using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoping_Card_DB_Connection.Models;
using Shoping_Card_DB_Connection.DataAccess;
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
            return View();
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
