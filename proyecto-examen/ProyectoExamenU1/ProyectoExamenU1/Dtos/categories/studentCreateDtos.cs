using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Dtos.categories
{
    public class studentCreateDtos
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string LastName { get; set; }
    }
}
