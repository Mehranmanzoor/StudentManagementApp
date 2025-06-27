using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Diagnostics;

namespace StudentManagementApp.Pages
{
    public class ErrorModel : PageModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = "An unexpected error occurred.";

        public void OnGet()
        {
            StatusCode = HttpContext.Response.StatusCode;

            if (StatusCode == 404)
            {
                ErrorMessage = "The page you were looking for could not be found.";
            }
            else if (StatusCode == 500)
            {
                ErrorMessage = "A server error occurred. Please try again later.";
            }
            else if (StatusCode == 408)
            {
                ErrorMessage = "Network timeout. Please check your internet connection.";
            }
            else
            {
                var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                ErrorMessage = feature?.Error.Message ?? "An unexpected error occurred.";
            }
        }
    }
}
