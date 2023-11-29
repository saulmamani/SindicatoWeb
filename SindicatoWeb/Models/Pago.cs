using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SindicatoWeb.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        [Required]
        public int Mes { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public decimal Monto { get; set; }

        //relaciones, foering key
        public int ChoferId { get; set; }
        public virtual Chofer? Chofer { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
