using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Admin.Entities
{
    [Table("Student")]
    public class Student : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public int NoOfCurrentCourses { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
