using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SindicatoWeb.Contexto;

namespace SindicatoWeb.Controllers
{
    public class LoginController : Controller
    {
        private MiContext _context;
        public LoginController(MiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = await _context.Usuarios
                                    .Where(x => x.CorreoElectronico == email && x.Password == password)
                                    .FirstOrDefaultAsync();

            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o password incorrecto!";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Logout()
        {

            return RedirectToAction("Index", "Login");
        }
    }
}
