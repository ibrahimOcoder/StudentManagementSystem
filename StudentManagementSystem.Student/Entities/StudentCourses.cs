using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Student.Entities
{
    [Table("StudentCourses")]
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    public class StudentCourses : EntityBaseWithoutId
    {
        public long StudentId { get; set; }

        public Student Student { get; set; }

        public long CourseId { get; set; }

        public Course Course { get; set; }

        public int CourseMarks { get; set; }
    }
}
