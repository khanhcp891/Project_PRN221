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

        public int totalAccount { get; set; }

        public int pageNo { get; set; }

        public int pageSize { get; set; }
        public ListAccountModel( PRN221_SP23Context dbContext)
        {
            //_logger = logger;
            _dbContext = dbContext;
        }
        public void OnGet(int p = 1, int s = 2)
        {
            ListAccount = _dbContext.Accounts.Skip((p - 1 ) * s).Take(s).ToList();
            pageSize = s;
            totalAccount = _dbContext.Accounts.Count();
            pageNo= p;
        }
    }
}
