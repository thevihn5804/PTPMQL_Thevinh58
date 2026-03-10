using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models.Entities
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Ma sinh vien la bat buoc.")]
        [Display(Name = "Ma sinh vien")]
        public string StudentCode { get; set; } = default!;

        [Required(ErrorMessage = "Ho ten sinh vien la bat buoc.")]
        [Display(Name = "Ho ten")]
        public string FullName { get; set; } = default!;

        [Display(Name = "Tuoi")]
        [Range(1, 150, ErrorMessage = "Tuoi phai nam trong khoang 1 den 150.")]
        public int? Age { get; set; }
    }
}