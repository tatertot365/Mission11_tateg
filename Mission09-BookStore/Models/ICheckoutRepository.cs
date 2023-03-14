using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission09_BookStore.Models
{
	public class ICheckoutRepository
	{
		IQueryable<Checkout> Checkouts { get; }

		public void SaveCheckout(Checkout checkout)
		{

		}

    }
}

