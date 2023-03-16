using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.ManageAccount
{
    public class UpdateAccountModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        [BindProperty]
        public Account account { get; set; }

        public UpdateAccountModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if(id == null)
            {
                return Content("Không tìm th?y id");
            }
            account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.IdAccount == id);
            if (account == null)
            {
                return Content("Không tìm th?y account");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
        {
            var a = await dbContext.Accounts.FirstOrDefaultAsync(x => x.IdAccount == account.IdAccount);
            if (a != null)
            {
                a.Email = account.Email;
                a.Name = account.Name;
            } else
            {
                return Content("Không th?y");
            }

            dbContext.SaveChangesAsync();
            return RedirectToPage("/Views/ManageAccount/ListAccount");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var a = await dbContext.Accounts.FirstOrDefaultAsync(x => x.IdAccount == account.IdAccount);
            if (a != null)
            {
                dbContext.Accounts.Remove(a);
                dbContext.SaveChangesAsync();
                return RedirectToPage("/Views/ManageAccount/ListAccount");
            }
            else
            {
                return Content("Không th?y");
            }
            return Page();
            
        }
    }
}
