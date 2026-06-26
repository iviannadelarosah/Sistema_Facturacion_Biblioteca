using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion_Biblioteca.Models;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Servicio> Servicios { get; set; } 
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Pago> Pagos { get; set; }
    public DbSet<DetalleFactura> DetallesFactura { get; set; }
}