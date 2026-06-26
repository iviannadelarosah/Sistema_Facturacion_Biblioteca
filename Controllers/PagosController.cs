using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Models;

public class PagosController : Controller
{
    private readonly BibliotecaContext _context;

    public PagosController(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var pagos = await _context.Pagos.ToListAsync();
        return View(pagos);
    }

    public IActionResult Create()
    {
        ViewBag.Facturas = new SelectList(_context.Facturas, "IdFactura", "IdFactura");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Pago pago)
    {
        ModelState.Remove("Factura");

        if (ModelState.IsValid)
        {
            var factura = await _context.Facturas.FindAsync(pago.IdFactura);
            if (factura == null)
            {
                ModelState.AddModelError("IdFactura", "La factura seleccionada no existe.");
            }
            else
            {
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction("Pagos", "Home");
            }

        }

        ViewBag.Facturas = new SelectList(_context.Facturas, "IdFactura", "IdFactura", pago.IdFactura);
        return View(pago);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var pago = await _context.Pagos.FindAsync(id);
        if (pago == null) return NotFound();

        ViewBag.Facturas = new SelectList(_context.Facturas, "IdFactura", "IdFactura", pago.IdFactura);
        return View(pago);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Pago pago)
    {
        if (id != pago.IdPago) return NotFound();

        ModelState.Remove("Factura");

        if (ModelState.IsValid)
        {
            _context.Update(pago);
            await _context.SaveChangesAsync();
            return RedirectToAction("Pagos", "Home");
        }

        ViewBag.Facturas = new SelectList(_context.Facturas, "IdFactura", "IdFactura", pago.IdFactura);
        return View(pago);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var pago = await _context.Pagos.FindAsync(id);
        if (pago == null) return NotFound();
        return View(pago);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pago = await _context.Pagos.FindAsync(id);
        if (pago != null)
        {
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Pagos", "Home");
    }
}