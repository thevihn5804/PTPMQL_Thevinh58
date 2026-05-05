using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVC.Models.Entities
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Ma sinh vien la bat buoc.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Ma sinh vien phai tu 3 den 20 ky tu.")]
        [Display(Name = "Ma sinh vien")]
        public string StudentCode { get; set; } = default!;

        [Required(ErrorMessage = "Ho ten sinh vien la bat buoc.")]
        [StringLength(100, ErrorMessage = "Ho ten khong duoc vuot qua 100 ky tu.")]
        [Display(Name = "Ho ten")]
        public string FullName { get; set; } = default!;

        [Required(ErrorMessage = "Tuoi la bat buoc.")]
        [Display(Name = "Tuoi")]
        [Range(1, 150, ErrorMessage = "Tuoi phai nam trong khoang 1 den 150.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email la bat buoc.")]
        [StringLength(100, ErrorMessage = "Email khong duoc vuot qua 100 ky tu.")]
        [EmailAddress(ErrorMessage = "Email khong dung dinh dang.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = default!;

        [Display(Name =  "Khoa")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui long chon khoa.")]
        public int FacultyID {get; set; }

        [ForeignKey(nameof(FacultyID))]
        public Faculty? Faculty {get; set; }
    }
}
