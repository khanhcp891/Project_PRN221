using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_PRN221.Model;
using System;
using System.Security.Principal;

namespace Project_PRN221.Pages.Views.Home
{
    public class LoginModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public LoginModel(PRN221_SP23Context context)
        {
            this.dbContext = context;
        }

        [BindProperty]
        public Account AccountRequest { get; set; }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            Account a = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Password.Equals(AccountRequest.Password) && x.Name.Equals(AccountRequest.Name));
            if (a != null)
            {
                HttpContext.Session.SetString("account", JsonConvert.SerializeObject(a));
                //HttpContext.Session.SetString("user", a.Name);
                //string str = HttpContext.Session.GetString("user");
                //string str = HttpContext.Session.GetString("account");
                //Account acc =  JsonConvert.DeserializeObject<Account>(str);
                //string s = acc.Name;

                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Views/Home/Login");
            }
        }
    }
}
