using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoping_Card_DB_Connection.DataAccess;
using Shoping_Card_DB_Connection.Models;
using System.Security.Cryptography;

namespace MVC_Shoping_Card.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISqlData _db;

        public AccountController(ISqlData db)
        {
            _db = db;
        }

        // GET: AccountController
        public ActionResult Register()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: model.Password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256/8));

                var user = new RegisterViewModel
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    EmailAddress = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Country = model.Country,    
                    State = model.State,    
                    City = model.City,
                    ZipCode = model.ZipCode,
                    CardNumber = model.CardNumber,
                };

                _db.Createuser(user);   
                return RedirectToAction(nameof(Register));  
            }
            else
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
