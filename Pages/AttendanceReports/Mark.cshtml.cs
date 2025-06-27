using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApp.Pages.AttendanceReports
{
    public class MarkModel : PageModel
    {
        private readonly AppDbContext _context;

        public MarkModel(AppDbContext context) => _context = context;

        public List<Student> Students { get; set; } = new();

        [BindProperty]
        public List<int> StudentIds { get; set; }

        [BindProperty]
        public List<bool> AttendanceStatus { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var today = DateTime.Today;

            for (int i = 0; i < StudentIds.Count; i++)
            {
                var alreadyMarked = await _context.Attendance
                    .AnyAsync(a => a.StudentId == StudentIds[i] && a.Date == today);
                if (alreadyMarked) continue;

                 _context.Attendance.Add(new Attendance
                {
                    StudentId = StudentIds[i],
                    Date = today,
                    Status = AttendanceStatus[i] ? "Present" : "Absent"
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
