using Microsoft.AspNetCore.Authorization;
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
            List<ProductViewModel> productsView = new List<ProductViewModel>();
            for (int i = 0; i < products.Count; i++)
            {
                ProductViewModel product = new ProductViewModel();
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

        public ActionResult Product(int id)
        {
            var product = _db.GetProductById(id).FirstOrDefault();

            ProductViewModel productView = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                Info = product.Info,
                Price = product.Price,
                Category = _db.GetCategoryById(product.CategoryId).FirstOrDefault().Name,
            };

            return View(productView);
        }

        [Authorize(Roles = "Admin")]
        // GET: ProducsController/Create
        public ActionResult Create()
        {
            var categories = _db.GetAllCategories();

            List<CategoryViewModel> categoriesView = new List<CategoryViewModel>();
            for (int i = 0; i < categories.Count; i++)
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
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
                CategoryId = model.CategoryId,
            };

            _db.CreateProduct(product);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        // GET: ProducsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _db.GetProductById(id).FirstOrDefault();
            var categories = _db.GetAllCategories();

            List<CategoryViewModel> categoriesView = new List<CategoryViewModel>();
            for (int i = 0; i < categories.Count; i++)
            {
                CategoryViewModel category = new CategoryViewModel()
                {
                    Id = categories[i].Id,
                    Name = categories[i].Name,
                };

                categoriesView.Add(category);
            }

            ProductCreateViewModel productEdit = new ProductCreateViewModel()
            {
                Categories = categoriesView,
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                Info = product.Info,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            return View(productEdit);
        }

        // POST: ProducsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ProductCreateViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var dublicate = _db.GetProductByName(model.Name);
            if(dublicate.Count > 1)
            {
                ModelState.AddModelError("Name", "This Product Is Already Exists");
                return View(model); 
            }

            ProductModel saveProduct = new ProductModel()
            {
                Id = model.Id,
                Name = model.Name,
                Amount = model.Amount,
                Info = model.Info,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };

            _db.EditProduct(saveProduct);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        // GET: ProducsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _db.GetProductById(id).FirstOrDefault();

            ProductViewModel productView = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Amount = product.Amount,
                Info = product.Info,
                Price = product.Price,
                Category = _db.GetCategoryById(product.CategoryId).FirstOrDefault().Name
            };

            return View(productView);
        }

        // POST: ProducsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var product = _db.GetProductById(id);
            
            if(product == null)
            {
                return NotFound();
            }

            _db.DeleteProduct(id);
            return RedirectToAction("Index");   
        }
    }
}
