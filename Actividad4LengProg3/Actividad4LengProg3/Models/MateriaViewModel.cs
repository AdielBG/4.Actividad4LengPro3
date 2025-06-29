using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Required(ErrorMessage = "Debe ingresar el codigo de la asignatura")]
        public string Codigo { get; set; }

        [Required(ErrorMessage ="Debe ingresar el nombre de la asignatura")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar los creditos de la asignatura")]
        [Range(1,10)]
        public int Creditos { get; set; }

        [Required(ErrorMessage = "Debe ingresar la carrera a la que pertenece la asignatura")]
        public string Carrera { get; set; }
    }
}
