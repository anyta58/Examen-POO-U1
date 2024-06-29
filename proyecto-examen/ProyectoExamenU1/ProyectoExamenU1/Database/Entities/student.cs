using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Database.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }

        // Data Annotations
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string LastName { get; set; }
    }
}
