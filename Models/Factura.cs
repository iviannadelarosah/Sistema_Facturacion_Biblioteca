using System.ComponentModel.DataAnnotations;
namespace Sistema_Facturacion_Biblioteca.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaFactura { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}