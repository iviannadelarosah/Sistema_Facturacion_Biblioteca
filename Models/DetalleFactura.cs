using System.ComponentModel.DataAnnotations;
namespace Sistema_Facturacion_Biblioteca.Models

{
    public class DetalleFactura
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public Factura Factura { get; set; } = null!;
        public int IdServicio { get; set; }
        public Servicio Servicio { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}