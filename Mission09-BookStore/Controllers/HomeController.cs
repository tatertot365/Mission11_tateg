using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_BookStore.Models;
using Mission09_BookStore.Models.ViewModels;

// Tate Gillespie Section 3 group 1
// Bookstore project
// The two bootstrap addons I used are in the Cart.cshtml page under the Pages folder

namespace Mission09_BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // This creates the context for the repo of books we have
        private BookstoreBooksRepository repo;

        public HomeController(ILogger<HomeController> logger, BookstoreBooksRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        // This controls the index page by checking what pages the user is on and outputting the correct books
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            // Updated model to account for category values to be able to sort books by category
            var x = new BooksViewModel
            {
                Books = repo.Books
                    .Where(b => b.Category == category || category == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo {
                    TotalNumBooks = (category == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

