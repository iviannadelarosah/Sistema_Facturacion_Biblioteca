using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Sistema_Facturacion_Biblioteca.Models;

public class UsuariosController : Controller
{
    private readonly BibliotecaContext _context;
    public UsuariosController(BibliotecaContext context) => _context = context;

    public async Task<IActionResult> Index() => View(await _context.Usuarios.ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            usuario.FechaRegistro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(usuario);
    }

    public async Task<IActionResult> Edit(int id) => View(await _context.Usuarios.FindAsync(id));

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario) return NotFound();
        _context.Update(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) => View(await _context.Usuarios.FindAsync(id));

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}