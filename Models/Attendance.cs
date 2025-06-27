using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? Student { get; set; } // ✅ Made nullable to prevent CS9035

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; } = null!; // ✅ Use null-forgiving operator
    }
}
