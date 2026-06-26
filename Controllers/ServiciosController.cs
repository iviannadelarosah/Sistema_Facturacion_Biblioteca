using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Models;

public class ServiciosController : Controller
{
    private readonly BibliotecaContext _context;

    public ServiciosController(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var servicios = await _context.Servicios.ToListAsync();
        return View(servicios);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Servicio servicio)
    {
        ModelState.Remove("DetallesFactura");

        if (ModelState.IsValid)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Servicios", "Home");

        }
        return View(servicio);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio == null) return NotFound();
        return View(servicio);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Servicio servicio)
    {
        if (id != servicio.IdServicio) return NotFound();

        ModelState.Remove("DetallesFactura");

        if (ModelState.IsValid)
        {
            _context.Update(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Servicios", "Home");
        }
        return View(servicio);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio == null) return NotFound();
        return View(servicio);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio != null)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Servicios", "Home");
    }
}