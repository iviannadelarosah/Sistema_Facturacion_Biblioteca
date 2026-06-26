using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Models;

namespace Sistema_Facturacion_Biblioteca.Controllers
{
    public class AuthController : Controller
    {
        private readonly BibliotecaContext _context;

        public AuthController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Email = model.Email,
                    Telefono = model.Telefono,
                    Password = model.Password,
                    Rol = !_context.Usuarios.Any(u => u.Rol == "Admin") ? "Admin" : "Empleado",
                    FechaRegistro = DateTime.Now
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Auth");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
                    HttpContext.Session.SetString("UsuarioRol", usuario.Rol);
                    return RedirectToAction("Dashboard", "Home");
                }

                ModelState.AddModelError("", "Credenciales incorrectas");
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}