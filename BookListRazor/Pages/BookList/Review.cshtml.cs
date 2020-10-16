using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class ReviewModel : PageModel
    {
        public Microsoft.AspNetCore.Http.HttpContext Context { get; }
        public readonly BookListRazorContext db;
        public ReviewModel(BookListRazorContext _db)
        {
            db = _db;
            
        }
        [BindProperty]
        public Review Review { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // Review.BookId = Convert.ToInt32(Context.Request.Query["id"]);
                string url = Request.GetDisplayUrl();
                //string id = a.Substring(a.IndexOf("?id=") + 4, a.IndexOf("&handler") - a.IndexOf("?id=") - 4);
                int afterIndex = url.IndexOf("&handler") - url.IndexOf("?id=") - 4;
                if (afterIndex > 0)
                {
                    Review.BookId = Convert.ToInt32(url.Substring(url.IndexOf("?id=") + 4, afterIndex));
                }
                else
                {
                    Review.BookId = Convert.ToInt32(url.Substring(url.IndexOf("?id=") + 4));
                }
                await db.Review.AddAsync(Review);
                await db.SaveChangesAsync();
                return RedirectToPage("Shop");
            }
            else
            {
                return Page();
            }
        }
    }
}