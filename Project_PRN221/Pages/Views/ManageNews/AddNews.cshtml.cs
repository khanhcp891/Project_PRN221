using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.ManageNews
{
    public class AddNewsModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public AddNewsModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public Post AddPostRequest { get; set; }

        public List<Authur> listAuthur { get; set; }

        public List<CategoryNews> listCate { get; set; }
        public void OnGet()
        {
            listAuthur = dbContext.Authurs.ToList();
            listCate= dbContext.CategoryNews.ToList();   
        }

        public async Task<IActionResult> OnPost()
        {

            var post = new Post
            {
                Title = AddPostRequest.Title,
                DatePost = AddPostRequest.DatePost,
                Concept = AddPostRequest.Concept,
                Description = AddPostRequest.Description,
                IdAuthur = AddPostRequest.IdAuthur,
                IdCategory = AddPostRequest.IdCategory
            };
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
            return RedirectToPage("/Index");

        }

    }
}

