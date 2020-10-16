using System;
using System.Collections.Generic;

namespace BookListRazor.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string Review1 { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
