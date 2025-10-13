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
                product.Id = products[i].Id;
                product.Category = _db.GetCategoryById(products[i].CategoryId).FirstOrDefault().Name;
                product.Name = products[i].Name;
                product.Amount = products[i].Amount;
                product.Info = products[i].Info;
                product.Price = products[i].Price;
                productsView.Add(product);
            }
            return View(productsView);
        }

        // GET: ProducsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProducsController/Create
        public ActionResult Create()
        {
            var categories = _db.GetAllCategories();

            List<CategoryViewModel> categoriesView = new List<CategoryViewModel>();
            for(int i = 0; i < categories.Count; i++)
            {
                CategoryViewModel category = new CategoryViewModel()
                {
                    Id = categories[i].Id,  
                    Name = categories[i].Name,  
                };
                categoriesView.Add(category);   
            }

            ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel()
            {
                Categories = categoriesView,    
            };

            return View(productCreateViewModel);
        }

        // POST: ProducsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var dublicate = _db.GetProductByName(model.Name);

            if (dublicate.Count > 0)
            {
                ModelState.AddModelError("Name", "This Product Is Already Exists");
                return View(model);
            }

            ProductModel product = new ProductModel()
            {
                Name = model.Name,
                Amount = model.Amount,  
                Info = model.Info,  
                Price = model.Price,    
                CategoryId = model.Category,
            };

            _db.CreateProduct(product);
            return Redirect("Index");
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
