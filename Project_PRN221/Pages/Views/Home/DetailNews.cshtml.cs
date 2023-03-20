using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.Home
{
    public class DetailNewsModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public Post post { get; set; }

        public List<Authur> listAuthur { get; set; }

        public List<Image> listImage { get; set; }

        public DetailNewsModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            listAuthur = dbContext.Authurs.ToList();
            listImage = dbContext.Images.ToList();

            if (id == null)
            {
                return Content("Không tìm thay id");
            }
            post = await dbContext.Posts.FirstOrDefaultAsync(x => x.IdPost == id);
            if (post == null)
            {
                return Content("Không tìm thay account");
            }
            return Page();
        }
    }
}
