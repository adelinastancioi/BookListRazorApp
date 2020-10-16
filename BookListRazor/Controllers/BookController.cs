using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{    [Route ("api/Book")]
     [ApiController]
    public class BookController : Controller
    {
        private readonly BookListRazorContext dbContext;

        public BookController(BookListRazorContext db)
        {
            dbContext = db; 
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = dbContext.Book.ToList() });
        }
    }
}