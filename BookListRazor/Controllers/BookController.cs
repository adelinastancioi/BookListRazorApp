using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{    [Route ("api/Book")]
     [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BookController(ApplicationDbContext db)
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