using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewNote { get; set; }
        public int BookId { get; set; }

    }
}
