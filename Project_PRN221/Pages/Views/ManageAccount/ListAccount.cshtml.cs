using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.ManageAccount
{
    public class ListAccountModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public List<Model.Account> ListAccount { get; set; }
        public ListAccountModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            ListAccount = dbContext.Accounts.ToList();
        }
    }
}
