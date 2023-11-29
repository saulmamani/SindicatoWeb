using Microsoft.AspNetCore.Identity;
using SindicatoWeb.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SindicatoWeb.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? CorreoElectronico { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Password { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string? NombreCompleto { get; set; }
        [Required]
        public RolEnum Rol { get; set; }

        //Relaciones
        public virtual List<Pago>? Pagos { get; set; }
    }
}
