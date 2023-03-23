using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_PRN221.Pages.Views.Home
{
    public class dangxuatModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            HttpContext.Session.Remove("account");
            return RedirectToPage("/Views/Home/Login");
        }
    }
}
