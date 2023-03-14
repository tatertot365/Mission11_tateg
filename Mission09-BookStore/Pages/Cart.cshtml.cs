using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_BookStore.Infrastructure;
using Mission09_BookStore.Models;

namespace Mission09_BookStore.Pages
{
	public class CartModel : PageModel
    {

        // This si the code for the Cart page that allows you to manage the returnURL and adding items to the basket
        private BookstoreBooksRepository repo { get; set; }
        //public Basket basket { get; set; }
        //public string ReturnUrl { get; set; }

        public CartModel (BookstoreBooksRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            basket.AddItem(b, 1);

            return RedirectToPage(new {ReturnUrl = returnUrl});

        }

        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage(  new {ReturnUrl = returnUrl});
        }
    }
}
