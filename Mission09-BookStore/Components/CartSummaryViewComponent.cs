using System;
using Microsoft.AspNetCore.Mvc;
using Mission09_BookStore.Models;

namespace Mission09_BookStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket cart;

        public CartSummaryViewComponent(Basket cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

