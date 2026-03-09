using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVC.Models
{
    [Table("Student")]
    public class Student()
    {
        [Key]
        public string studentNumber { get; set; } = default!;
        public string fullName { get; set; }
    }
}