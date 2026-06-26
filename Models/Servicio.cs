using System.ComponentModel.DataAnnotations;
namespace Sistema_Facturacion_Biblioteca.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }
        [Required]
        public string NombreServicio { get; set; } = string.Empty;
        [Required]
        public decimal Precio { get; set; }
        public ICollection<DetalleFactura> DetallesFactura { get; set; }
    }
}