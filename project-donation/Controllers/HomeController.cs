using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_donation.Models;
using Donation_Infrastructure.IRepository;

namespace project_donation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IusuarioRepository _repo;

        public HomeController(ILogger<HomeController> logger, IusuarioRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string pasword)
        {
            var user = _repo.Getall().FirstOrDefault(u => u.username == username && u.pasword == pasword);

            if (user == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }

            if (user.rol == "admin")
                return RedirectToAction("PanelAdmin");
            else
                return RedirectToAction("PanelCliente");
        }

        public IActionResult PanelAdmin()
        {
            return View(); 
        }

        public IActionResult PanelCliente()
        {
            return View(); 
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

