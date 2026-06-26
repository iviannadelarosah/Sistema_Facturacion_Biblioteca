using System.ComponentModel.DataAnnotations;
namespace Sistema_Facturacion_Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Apellido { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        public string Rol { get; set; } = "Empleado";
        [Required]
        public string Password { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}