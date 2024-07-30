using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Student.Models
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }
    }
}
