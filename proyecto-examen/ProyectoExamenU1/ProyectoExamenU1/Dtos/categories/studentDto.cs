using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1.Dtos.categories
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
