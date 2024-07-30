using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Admin.Entities
{
    [Table("Course")]
    public class Course : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
