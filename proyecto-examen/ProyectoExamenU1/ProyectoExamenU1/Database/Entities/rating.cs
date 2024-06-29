using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Database.Entities
{
    public class rating
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        // Data Annotations
        [Display(Name = "Materia")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Subject { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Grade { get; set; }
    }
}
