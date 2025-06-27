using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementApp.Models;
using StudentManagementApp.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }
    }
}
