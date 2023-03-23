using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.Home
{
    public class ChangePassModel : PageModel
    {
        private readonly PRN221_SP23Context _context;

        [BindProperty]
        public Account ChangePass { get; set; }

        public ChangePassModel(PRN221_SP23Context context)
        {
            this._context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string oldPass, string newPass, string newPassRepeat)
        {
            if(newPass.Equals(newPassRepeat))
            {
                string str = HttpContext.Session.GetString("account");
                Account acc = JsonConvert.DeserializeObject<Account>(str);
                Account account = await _context.Accounts.FirstOrDefaultAsync(x => x.IdAccount == acc.IdAccount);
                account.Password = newPass;
                _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Views/Home/ChangePass");
            }
            return Page();
        }
    }
}
