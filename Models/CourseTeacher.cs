using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSWeb2022.Models
{
    public class CourseTeacher
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}