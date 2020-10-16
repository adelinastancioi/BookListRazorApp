using System;
using System.Collections.Generic;

namespace BookListRazor.Models
{
    public partial class Book
    {
        public Book()
        {
            Cart = new HashSet<Cart>();
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public float? Price { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
