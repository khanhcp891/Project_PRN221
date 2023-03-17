using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;


namespace Project_PRN221.Pages.Views.ManageAccount
{
    public class AddAccountModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public AddAccountModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        } 

        [BindProperty]
        public Account AddAccountRequest { get; set; }
        public void OnGet()
        {
        }



        public async Task<IActionResult> OnPost(string passRepeat)
        {
            Account a = dbContext.Accounts.FirstOrDefault(x => x.Email == AddAccountRequest.Email);
            if(a == null)
            {
                if(AddAccountRequest.Password.Equals(passRepeat))
                {
                    var account = new Account
                    {
                        Name = AddAccountRequest.Name,
                        Email = AddAccountRequest.Email,
                        Password = AddAccountRequest.Password,
                        IsAdmin = false
                    };
                    dbContext.Accounts.Add(account);
                    await dbContext.SaveChangesAsync();
                    return RedirectToPage("/Index"); 
                    
                } else
                {
                    return RedirectToPage("/Views/ManageAccount/AddAccount");
                }
                
            } else
            {
                return RedirectToPage("/Views/ManageAccount/AddAccount");
            }
            
        }
    }
}
