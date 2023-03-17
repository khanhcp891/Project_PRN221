using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Model;
using System.Security.Principal;

namespace Project_PRN221.Pages.Views.ManageNews
{
    public class UpdateNewsModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        [BindProperty]
        public Post post { get; set; }

        public List<Authur> listAuthur { get; set; }

        public List<CategoryNews> listCate { get; set; }

        public UpdateNewsModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            listAuthur = dbContext.Authurs.ToList();
            listCate = dbContext.CategoryNews.ToList();
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

        public async Task<IActionResult> OnPostUpdate()
        {
            var p = await dbContext.Posts.FirstOrDefaultAsync(x => x.IdPost == post.IdPost);
            if (p != null)
            {
                p.Title = post.Title;
                p.DatePost = post.DatePost;
                p.Description = post.Description;
                p.Concept = post.Concept;
                p.IdAuthur = post.IdAuthur;
                p.IdCategory = post.IdCategory;
            }
            else
            {
                return Content("Không thay");
            }

            dbContext.SaveChangesAsync();
            return RedirectToPage("/Views/ManageNews/ListNews");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var p = await dbContext.Posts.FirstOrDefaultAsync(x => x.IdPost == post.IdPost);
            if (p != null)
            {
                dbContext.Posts.Remove(p);
                dbContext.SaveChangesAsync();
                return RedirectToPage("/Views/ManageAccount/listNews");
            }
            else
            {
                return Content("Không thay");
            }
            return Page();

        }
    }
}
