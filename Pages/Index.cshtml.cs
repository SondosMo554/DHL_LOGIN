using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DHL_LOGIN_FINAL.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Account/Login", new { email = Request.Form["Username"], password = Request.Form["Password"] });
        }
    }
}
