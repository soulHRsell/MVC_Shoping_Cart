using Microsoft.AspNetCore.Mvc;
using MVC_Shoping_Card.Models;
using Shoping_Card_DB_Connection.DataAccess;
using Shoping_Card_DB_Connection.Models;

namespace MVC_Shoping_Card.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ISqlData _db;

        public ProductsController(ISqlData db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<ProductModel> dbproducts = _db.GetProducts();
            List<ProductsViewModel> products = new List<ProductsViewModel>();
            for (int i = 0; i < dbproducts.Count; i++)
            {
                ProductsViewModel product = new ProductsViewModel();
                product.Category = dbproducts[i].Category;
                product.Name = dbproducts[i].Name;
                product.Amount = dbproducts[i].Amount;
                product.Info = dbproducts[i].Info;
                products.Add(product);
            }
            return View(products);
        }

        // GET: ProducsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProducsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProducsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProducsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: ProducsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProducsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
