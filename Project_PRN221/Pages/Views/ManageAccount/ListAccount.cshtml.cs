using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.ManageAccount
{
    public class ListAccountModel : PageModel
    {
        //private readonly ILogger<ListAccountModel> _logger;
        private readonly PRN221_SP23Context _dbContext;


        public List<Account> ListAccount { get; set; } = default!;
        public ListAccountModel( PRN221_SP23Context dbContext)
        {
            //_logger = logger;
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            ListAccount = _dbContext.Accounts.ToList();
            //if(ListAccount== null)
            //{
            //} else
            //{

            //}
        }
    }
}
