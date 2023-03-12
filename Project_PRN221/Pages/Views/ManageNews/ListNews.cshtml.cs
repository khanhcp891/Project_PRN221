using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.ManageNews
{
    public class ListNewsModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public List<Model.Account> ListAccount { get; set; }

        public ListNewsModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            ListAccount = dbContext.Accounts.ToList();
        }
    }
}
