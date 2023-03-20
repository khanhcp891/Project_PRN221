using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.Home
{
    public class ChuyenNhuongNewsModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public List<Post> listNewPost { get; set; } = default!;

        public List<Post> listPost { get; set; } = default!;

        public List<Post> listPostShow { get; set; } = default!;

        public List<Image> listImage { get; set; } = default!;

        public const int ITEM_PER_PAGE = 3;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }

        public int countPages { get; set; }

        public ChuyenNhuongNewsModel(PRN221_SP23Context context)
        {
            this.dbContext = context;
        }
        public void OnGet()
        {
            listPost = dbContext.Posts.Where(x => x.IdCategory == 5 || x.IdCategory == 4).ToList();
            listNewPost = dbContext.Posts.Take(6).ToList();
            int totalPost = listPost.Count;
            countPages = (int)Math.Ceiling((double)totalPost / ITEM_PER_PAGE);
            listPostShow = listPost.Skip((currentPage - 1) * 3).Take(ITEM_PER_PAGE).ToList();
            if (currentPage < 1) currentPage = 1;

            if (currentPage > countPages) currentPage = countPages;

            listImage = dbContext.Images.ToList();
        }
    }
}
