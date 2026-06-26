using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Models;

public class FacturasController : Controller
{
    private readonly BibliotecaContext _context;

    public FacturasController(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var facturas = await _context.Facturas.ToListAsync();
        return View(facturas);
    }

    public IActionResult Create()
    {
        ViewBag.Usuarios = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Factura factura)
    {
        ModelState.Remove("Usuario");
        ModelState.Remove("Detalles");
        ModelState.Remove("Pagos");

        if (ModelState.IsValid)
        {
            var usuario = await _context.Usuarios.FindAsync(factura.IdUsuario);
            if (usuario == null)
            {
                ModelState.AddModelError("IdUsuario", "El usuario seleccionado no existe.");
            }
            else
            {
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction("Facturas", "Home");
            }
        }

        ViewBag.Usuarios = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", factura.IdUsuario);
        return View(factura);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null) return NotFound();

        ViewBag.Usuarios = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", factura.IdUsuario);
        return View(factura);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Factura factura)
    {
        if (id != factura.IdFactura) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction("Facturas", "Home");
        }
        return View(factura);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null) return NotFound();
        return View(factura);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura != null)
        {
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Facturas", "Home");
    }
}