using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;

namespace StudentManagementApp.Pages.AttendanceReports
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context) => _context = context;

        public List<Attendance> Records { get; set; } = new();

        public async Task OnGetAsync()
        {
            Records = await _context.Attendance
                .Include(a => a.Student)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }
    }
}
