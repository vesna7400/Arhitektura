using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Arhitektura.Roles;
using Arhitektura.Models;

namespace Arhitektura.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                User foundUser = _userRepository.GetUser(user.Username, user.Password);
                if (foundUser != null)
                {
                    if (foundUser.Username == "admin")
                    {
                        HttpContext.Session.SetString("Role", "admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Role", "user");
                    }
                    HttpContext.Session.SetString("Username", foundUser.Username);
                    return RedirectToAction("Index");
                } 
                ModelState.AddModelError(string.Empty, "Pogrešno korisničko ime ili lozinka");
            }           
            return View("Index", user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if(_userRepository.GetUsername(user.Username))
                {
                    _userRepository.Create(user);
                    return RedirectToAction("Index");
                }else
                {
                    ModelState.AddModelError(string.Empty, "Username je već postojeći!");
                }
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Logout(bool logout)
        {
            if (logout)
            {
                HttpContext.Session.SetString("Role", "guest");
                HttpContext.Session.SetString("Username", "");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
