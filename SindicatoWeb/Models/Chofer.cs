using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindicatoWeb.Models
{
    public class Chofer
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(6), MaxLength(10)]
        public string? Ci { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        [Display(Name = "Nombre del Chofer")]
        public string? NombreCompleto { get; set; }
        public string? Foto { get; set; }

        //para manejo de archivos
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }

        //Relaciones
        public virtual List<Pago>? Pagos { get; set; }
    }
}
