using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission09_BookStore.Models
{
	public interface ICheckoutRepository
	{

		// This is an interface that is then implemented by the EFCheckoutRepository
		IQueryable<Checkout> Checkouts { get; }

		public void SaveCheckout(Checkout checkout)
		{

		}

    }
}

