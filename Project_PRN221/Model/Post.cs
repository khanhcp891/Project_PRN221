using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Post
    {
        public Post()
        {
            Images = new HashSet<Image>();
        }

        public int IdPost { get; set; }
        public string Title { get; set; } = null!;
        public DateTime DatePost { get; set; }
        public string Concept { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? IdAuthur { get; set; }
        public int? IdCategory { get; set; }

        public virtual Authur? IdAuthurNavigation { get; set; }
        public virtual CategoryNews? IdCategoryNavigation { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
