using System.ComponentModel.DataAnnotations;

namespace Kian.Task.Presentation.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Range(minimum: 5000, maximum: 15000)]
        public double Salary { get; set; }
    }
}
