using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class CartModel : PageModel
    {
        private readonly BookListRazorContext BookListRazorContext;
        public CartModel(BookListRazorContext db)
        {
            this.BookListRazorContext = db;
        }


        public IEnumerable<Cart> Items { get; set; }
        public async Task OnGetAsync()
        {
          //  Books = await BookListRazorContext.Book.ToListAsync();
            string url = Request.GetDisplayUrl();
            if (url.Contains("?id=-1"))
            {
                BookListRazorContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Cart]");
                await BookListRazorContext.SaveChangesAsync();

            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(url.Substring(url.IndexOf("?id=") + 4, url.IndexOf("&handler") - url.IndexOf("?id=") - 4));

                    var book = await BookListRazorContext.Book.FindAsync(id);

                    Cart cart = new Cart();
                    cart.BookId = book.Id;
                    cart.Name = book.Name;
                    cart.Price = book.Price;

                    BookListRazorContext.Cart.Add(cart);
                    await BookListRazorContext.SaveChangesAsync();
                }
                catch
                {

                }
            }
            Items = await BookListRazorContext.Cart.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            
            var item = BookListRazorContext.Cart.Where(x => x.BookId == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            BookListRazorContext.Cart.Remove(item);

            await BookListRazorContext.SaveChangesAsync();
            return RedirectToPage("Cart");
        }

     
    }
}