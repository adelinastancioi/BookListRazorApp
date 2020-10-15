using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class ReviewModel : PageModel
    {
        public readonly ApplicationDbContext db;
        public ReviewModel(ApplicationDbContext _db)
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
                await db.Reviews.AddAsync(Review);
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