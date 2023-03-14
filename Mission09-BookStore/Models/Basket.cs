using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mission09_BookStore.Models
{
	public class Basket
	{

		// this is the basket class that shows basket line items as well
		public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

		public virtual void AddItem(Books b, int qty)
		{
			BasketLineItem line = Items
				.Where(x => x.Book.BookId == b.BookId)
				.FirstOrDefault();

			if (line == null)
			{
				Items.Add(new BasketLineItem
				{
					Book = b,
					Quantity = qty
				});
			}
			else
			{
				line.Quantity += qty;
			}
		}

        public virtual double CalculateTotal()
        {
			double sum = Items.Sum(x => x.Quantity * x.Book.Price);

			return sum;
        }

		public virtual void RemoveItem(Books book)
		{
			Items.RemoveAll(x => x.Book.BookId == book.BookId);
		}

		public virtual void ClearBasket()
		{
			Items.Clear();
		}

    }


    public class BasketLineItem
	{
		[Key]
		public int LineID { get; set; }
		public Books Book { get; set; }
		public int Quantity { get; set; }
	}
}

