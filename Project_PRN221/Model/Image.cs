using System;
using System.Collections.Generic;

namespace Project_PRN221.Model
{
    public partial class Image
    {
        public int IdImg { get; set; }
        public string? Name { get; set; }
        public int? PostId { get; set; }

        public virtual Post? Post { get; set; }
    }
}
