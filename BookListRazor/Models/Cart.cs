using System;
using System.Collections.Generic;

namespace BookListRazor.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
