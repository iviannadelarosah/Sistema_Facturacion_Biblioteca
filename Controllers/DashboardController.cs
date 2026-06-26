using Microsoft.AspNetCore.Mvc;

namespace Sistema_Facturacion_Biblioteca.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BibliotecaContext _context;

        public DashboardController(BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            ViewBag.TotalUsuarios = _context.Usuarios.Count();
            ViewBag.TotalServicios = _context.Servicios.Count();
            ViewBag.TotalFacturas = _context.Facturas.Count();
            ViewBag.TotalPagos = _context.Pagos.Count();

            ViewBag.UltimosUsuarios = _context.Usuarios
                .OrderByDescending(u => u.FechaRegistro)
                .Take(5)
                .ToList();

            ViewBag.UltimasFacturas = _context.Facturas
                .OrderByDescending(f => f.FechaFactura)
                .Take(5)
                .ToList();

            ViewBag.UltimosPagos = _context.Pagos
                .OrderByDescending(p => p.FechaPago)
                .Take(5)
                .ToList();

            return View();
        }
    }
}
