using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project_PRN221.Model;

namespace Project_PRN221.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly PRN221_SP23Context dbContext;

        public List<Post> listPostCN { get; set; } = default!;

        public List<Post> listPostBDVN { get; set; } = default!;

        public List<Post> listPostPremierLeague { get; set; } = default!;

        public List<Post> listPostLaLiga { get; set; } = default!;

        public List<Post> listPostSeriA { get; set; } = default!;

        public List<Image> listImage { get; set; } = default!;


        public IndexModel(PRN221_SP23Context context)
        {
            this.dbContext = context;
        }

        public void OnGet()
        {

            listPostCN = dbContext.Posts.Where(x => x.IdCategory == 5 || x.IdCategory == 4).Take(3).ToList();
            listPostBDVN = dbContext.Posts.Where(x => x.IdCategory > 0 && x.IdCategory < 5).Take(3).ToList();
            listPostPremierLeague = dbContext.Posts.Where(x => x.IdCategory == 6).Take(3).ToList();
            listPostLaLiga = dbContext.Posts.Where(x => x.IdCategory == 7).Take(3).ToList();
            listPostSeriA = dbContext.Posts.Where(x => x.IdCategory == 8).Take(3).ToList();
            listImage = dbContext.Images.ToList();
        }
    }
}