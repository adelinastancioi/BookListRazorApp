﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class EditModel : PageModel
    {
        public readonly BookListRazorContext db;

        public EditModel(BookListRazorContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookEdit = await db.Book.FindAsync(Book.Id);
                BookEdit.Name = Book.Name;
                BookEdit.Author = Book.Author;
                BookEdit.Isbn = Book.Isbn;

                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}