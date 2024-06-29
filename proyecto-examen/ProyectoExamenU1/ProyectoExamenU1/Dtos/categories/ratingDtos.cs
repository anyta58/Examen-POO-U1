using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Dtos.categories
{
    public class ratingDtos
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
    }
}
