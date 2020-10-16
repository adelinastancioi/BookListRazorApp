using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace BookListRazor.Pages.BookList
{
    public class ShopModel : PageModel
    {
        private readonly BookListRazorContext BookListRazorContext;
        public ShopModel(BookListRazorContext db)
        {
            this.BookListRazorContext = db;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGetAsync()
        {
            Books = await BookListRazorContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            var book = await BookListRazorContext.Book.FindAsync(1);
            if (book == null)
            {
                return NotFound();
            }
            Cart cart = new Cart();
            cart.BookId = book.Id;
            cart.Name = book.Name;
            cart.Price = book.Price;

           

      
            BookListRazorContext.Cart.Add(cart);
            await BookListRazorContext.SaveChangesAsync();
            return RedirectToPage("Cart");
        }
        private void buttonClick()
        {
            RedirectToPage("Cart");
            return;
        }
    }
}