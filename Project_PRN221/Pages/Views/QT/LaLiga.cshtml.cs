using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages.Views.QT
{
    public class LaLigaModel : PageModel
    {
        private readonly PRN221_SP23Context dbContext;

        public List<Post> listPost { get; set; } = default!;

        public List<Post> listPostShow { get; set; } = default!;

        public List<Image> listImage { get; set; } = default!;

        public const int ITEM_PER_PAGE = 2;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }

        public int countPages { get; set; }

        public LaLigaModel(PRN221_SP23Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            listPost = dbContext.Posts.Where(x => x.IdCategory == 7).ToList();
            int totalPost = listPost.Count;
            countPages = (int)Math.Ceiling((double)totalPost / ITEM_PER_PAGE);
            listPostShow = listPost.Skip((currentPage - 1) * 2).Take(ITEM_PER_PAGE).ToList();
            if (currentPage < 1) currentPage = 1;

            if (currentPage > countPages) currentPage = countPages;

            listImage = dbContext.Images.ToList();


        }
    }
}
