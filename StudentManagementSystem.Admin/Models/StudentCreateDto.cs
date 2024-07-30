using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Admin.Models
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string StudentEmail { get; set; }
    }
}
