using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.Home
{
    public class InformationModel : PageModel
    {
        private readonly PRN221_SP23Context _context;

        public Account account { get; set; }
        public InformationModel(PRN221_SP23Context context)
        {
            this._context = context;
        }
        public async void OnGet()
        {
            string str = HttpContext.Session.GetString("account");
            Account acc = JsonConvert.DeserializeObject<Account>(str);
            account = await _context.Accounts.FirstOrDefaultAsync(x => x.IdAccount == acc.IdAccount);

        }
    }
}
