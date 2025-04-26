using Donation_Domain.entities;
using Donation_Infrastructure.Ddcontext;
using Microsoft.AspNetCore.Mvc;

namespace project_donation.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioContex _context;

        public UsuarioController(UsuarioContex context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.usuario.FirstOrDefault(u => u.username == username && u.pasword == password);

            if (user != null)
            {
                HttpContext.Session.SetString("username", user.username);
                HttpContext.Session.SetString("rol", user.rol);

                if (user.rol == "admin")
                {
                    return RedirectToAction("PanelAdmin", "Home"); 
                }
                else if (user.rol == "cliente")
                {
                    return RedirectToAction("PanelCliente", "Home"); 
                }
                else
                {
                    return View("Access negado");
                }
            }

            ViewBag.Error = "Incorrect username or password.";
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Usuario usuario)
        {
            if (usuario.rol.ToLower() == "admin")
            {
                ModelState.AddModelError("rol", "You don't can create administrators from here.");
                return View(usuario);
            }

            var exists = _context.usuario.Any(u => u.username == usuario.username);
            if (exists)
            {
                ViewBag.Error = "That username already exists";
                return View(usuario);
            }

            
            return RedirectToAction("PanelCliente", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
