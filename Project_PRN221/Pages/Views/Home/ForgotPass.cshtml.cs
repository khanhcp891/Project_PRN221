using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Model;
using System.Net.Mail;
using System.Text;

namespace Project_PRN221.Pages.Views.Home
{
    public class ForgotPassModel : PageModel
    {
        private readonly PRN221_SP23Context _context;

        public ForgotPassModel(PRN221_SP23Context context)
        {
            this._context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string email)
        {
            if(email== null)
            {
                return RedirectToPage("/Views/Home/ForgotPass");
            }
            Account account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(email));
            if(account != null)
            {
                sendPassword(email, account.Password);
                return RedirectToPage("/Views/Home/Login");
            }
            return Page();
        }

        public string sendPassword(String sender, String pass)
        {
            // Create a new MailMessage object
            MailMessage message = new MailMessage();
            message.From = new MailAddress("khanhpdhe153664@fpt.edu.vn");
            message.To.Add(new MailAddress(sender));
            message.Subject = "Password";

            message.Body = "This is your password: " + pass;
            // Create a new SmtpClient object
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("khanhpdhe153664@fpt.edu.vn", "1123581321");
            smtpClient.EnableSsl = true;

            // Send the email message
            smtpClient.Send(message);
            return pass;
        }
        
    }
}
