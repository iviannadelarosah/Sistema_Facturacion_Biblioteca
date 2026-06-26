namespace Sistema_Facturacion_Biblioteca.Models
{
    public class Dashboard
    {
        public int TotalUsuarios { get; set; }
        public int TotalServicios { get; set; }
        public int TotalFacturas { get; set; }
        public int TotalPagos { get; set; }
        public List<Usuario> UltimosUsuarios { get; set; }
        public List<Factura> UltimasFacturas { get; set; }
    }
}