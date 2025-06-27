using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;

namespace StudentManagementApp.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; } = new();
        public List<Attendance> TodayRecords { get; set; } = new();

        public int TotalStudents { get; set; }
        public int TotalAttendance { get; set; }
        public int TodayAttendance { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Students.OrderByDescending(s => s.Id).Take(5).ToListAsync();

            TotalStudents = await _context.Students.CountAsync();
            TotalAttendance = await _context.Attendance.CountAsync();
            TodayAttendance = await _context.Attendance
                .CountAsync(a => a.Date == DateTime.Today);

            TodayRecords = await _context.Attendance
                .Include(a => a.Student)
                .Where(a => a.Date == DateTime.Today)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }
    }
}
