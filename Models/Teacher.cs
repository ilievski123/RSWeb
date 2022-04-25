using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSWeb2022.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        public string? Degree { get; set; }
        [Display(Name = "Academic Rank")]
        [StringLength(25)]
        public string? AcademicRank { get; set; }
        [Display(Name = "Office Number")]
        [StringLength(10)]
        public string? OfficeNumber { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        [NotMapped]
        public ICollection<Course> Courses1 { get; set; }
        [NotMapped]
        public ICollection<Course> Courses2 { get; set; }
    }
}
