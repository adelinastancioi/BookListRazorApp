using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly BookListRazorContext BookListRazorContext;
        public IndexModel(BookListRazorContext db)
        {
            this.BookListRazorContext = db;
        }
        public IEnumerable<Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            Books = await BookListRazorContext.Book.ToListAsync();
        }

     
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await BookListRazorContext.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            try
            {
                var reviews = BookListRazorContext.Review.Where(x => x.BookId == id).ToList();
                foreach (Review review in reviews)
                    BookListRazorContext.Review.Remove(review);
                await BookListRazorContext.SaveChangesAsync();
            }
            catch { }
            try
            {
                var items = BookListRazorContext.Cart.Where(x => x.BookId == id).ToList();
                foreach (Cart item in items)
                    BookListRazorContext.Cart.Remove(item);
                await BookListRazorContext.SaveChangesAsync();
            }
            catch { }
            BookListRazorContext.Book.Remove(book);
            await BookListRazorContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}




