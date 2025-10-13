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
            List<ProductModel> products = _db.GetProducts();
            List<ProductsViewModel> productsView = new List<ProductsViewModel>();
            for (int i = 0; i < products.Count; i++)
            {
                ProductsViewModel product = new ProductsViewModel();
                product.Category = products[i].Category;
                product.Name = products[i].Name;
                product.Amount = products[i].Amount;
                product.Info = products[i].Info;
                product.Price = products[i].Price;
                productsView.Add(product);
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
