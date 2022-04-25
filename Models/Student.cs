using System.ComponentModel.DataAnnotations;

namespace RSWeb2022.Models
{
    public class Student
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        [StringLength(10)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }

        [Display(Name = "Acquired Credits")]
        public int? AcquiredCredits { get; set; }

        [Display(Name = "Current Semester")]
        public int? CurrentSemestar { get; set; }

        [StringLength(25)]
        [Display(Name = "Education Level")]
        public string? EducationLevel { get; set; }

        public ICollection<Enrollment> Courses { get; set; }
    }
}
