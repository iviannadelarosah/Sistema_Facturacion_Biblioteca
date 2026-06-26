using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Controllers;
using Sistema_Facturacion_Biblioteca.Models;

public class HomeController : Controller
{
    private readonly BibliotecaContext _context;

    public HomeController(BibliotecaContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public async Task<IActionResult> Servicios()
    {
        var servicios = await _context.Servicios.ToListAsync();
        return View(servicios);
    }

    public async Task<IActionResult> Facturas()
    {
        var facturas = await _context.Facturas.ToListAsync();
        return View(facturas);
    }

    public async Task<IActionResult> Pagos()
    {
        var pagos = await _context.Pagos.ToListAsync();
        return View(pagos);
    }
}
