using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Dtos.categories
{
    public class ratingCreateDto
    {
        [Display(Name = "Materia")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Subject { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Grade { get; set; }
    }
}
