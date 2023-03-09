using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class CategoryNews
    {
        public CategoryNews()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string CodeConcept { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
