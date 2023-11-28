using Microsoft.AspNetCore.Identity;
using SindicatoWeb.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SindicatoWeb.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? CorreoElectronico { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? NombreCompleto { get; set; }
        public RolEnum Rol { get; set; }
    }
}
