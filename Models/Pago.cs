using System.ComponentModel.DataAnnotations;
namespace Sistema_Facturacion_Biblioteca.Models
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public int IdFactura { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
