using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Authur
    {
        public Authur()
        {
            Posts = new HashSet<Post>();
        }

        public int IdAuthur { get; set; }
        public string AuthurName { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
