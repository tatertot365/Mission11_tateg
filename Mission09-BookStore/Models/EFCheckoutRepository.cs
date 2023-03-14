using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission09_BookStore.Models
{
	public class EFCheckoutRepository : ICheckoutRepository
	{

		// This is an extension of the ICheckoutRepository that does the actual saving of the carts to the database
		private BookstoreContext context { get; set; }

		public EFCheckoutRepository (BookstoreContext temp)
		{
			context = temp;
		}

		public IQueryable<Checkout> Checkouts => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book);

		public void SaveCheckout(Checkout checkout)
		{
			context.AttachRange(checkout.Lines.Select(x => x.Book));

			if (checkout.CartId == 0)
			{
				context.Checkouts.Add(checkout);
			}

			context.SaveChanges();
		}
	}
}

