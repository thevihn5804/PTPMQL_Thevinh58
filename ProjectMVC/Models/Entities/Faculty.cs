using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models.Entities
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }

        [Required(ErrorMessage = "Ten khoa la bat buoc.")]
        [StringLength(100, ErrorMessage = "Ten khoa toi da 100 ky tu.")]
        [Display(Name = "Khoa")]
        public string FacultyName { get; set; } = string.Empty;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}