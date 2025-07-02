using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Actividad4LengProg3.Models
{
    public class CalificacionViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La matrícula del estudiante es requerida")]
        [Display(Name = "Matrícula del Estudiante")]
        public string MatriculaEstudiante { get; set; }

        [Required(ErrorMessage = "El código de la materia es requerido")]
        [Display(Name = "Código de Materia")]
        public string CodigoMateria { get; set; }

        [Required(ErrorMessage = "La nota es requerida")]
        [Range(0, 100, ErrorMessage = "La nota debe estar entre 0 y 100")]
        [Display(Name = "Nota")]
        public decimal Nota { get; set; }

        [Required(ErrorMessage = "El período es requerido")]
        [Display(Name = "Período")]
        public string Periodo { get; set; }

        // Propiedades de navegación para las relaciones
        [ForeignKey("MatriculaEstudiante")]
        public virtual EstudianteViewModel Estudiante { get; set; }

        [ForeignKey("CodigoMateria")]
        public virtual MateriaViewModel Materia { get; set; }
    }

}

