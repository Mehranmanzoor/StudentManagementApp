using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string Name { get; set; }

        [Range(1, 150)]
        public int Age { get; set; }

        [Required]
        public required string Grade { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
    }
}
