using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVC_Shoping_Card.Models;
using Shoping_Card_DB_Connection.DataAccess;
using Shoping_Card_DB_Connection.Models;
using System.Security.Claims;

namespace MVC_Shoping_Card.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISqlData _db;

        public AccountController(ISqlData db)
        {
            _db = db;
        }

        // GET: AccountController for Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: AccountController for Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: AccountController/Create for Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    Username = model.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
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
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return View();
            }
        }

        // POST: AccountController/Create for Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, bool rememberMe)
        {
            var user = _db.GetUserByUsername(model.Username);


            if (user.Count != 0 && BCrypt.Net.BCrypt.Verify(model.Password, user[0].Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user[0].Id.ToString()),
                    new Claim(ClaimTypes.Name, user[0].Username),
                    new Claim(ClaimTypes.Role, user[0].IsAdmin ? "Admin" : "User")
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = rememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddHours(2)
                };

                await HttpContext.SignInAsync("Cookies", principal, authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<UserModel> dbuser = _db.GetUserById(Int32.Parse(userId));

            UserEditViewModel user = new UserEditViewModel();
            user.Username = dbuser[0].Username;
            user.EmailAddress = dbuser[0].EmailAddress;
            user.FirstName = dbuser[0].FirstName;
            user.LastName = dbuser[0].LastName;
            user.Country = dbuser[0].Country;
            user.State = dbuser[0].State;
            user.City = dbuser[0].City;
            user.ZipCode = dbuser[0].ZipCode;
            user.CardNumber = dbuser[0].CardNumber;

            return View(user);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                UserEditModel editedUser = new UserEditModel();
                editedUser.Username = model.Username;   
                editedUser.EmailAddress = model.EmailAddress;
                editedUser.FirstName = model.FirstName; 
                editedUser.LastName = model.LastName;   
                editedUser.Country = model.Country; 
                editedUser.State = model.State; 
                editedUser.City = model.City;   
                editedUser.ZipCode = model.ZipCode; 
                editedUser.CardNumber = model.CardNumber;

                _db.EditUserInfo(userId, editedUser);
                return RedirectToAction("Index", "Home");   
            }
            return View();
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
