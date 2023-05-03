﻿using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Context
{
	public interface IApplicationContext
	{
		DbSet<User> User { get; set; }
		DbSet<Advertisment> Advertisment { get; set; }
		DbSet<Booking> Booking { get; set; }
		DbSet<Review> Review { get; set; }

		Task<int> SaveChangesAsync();
		void BeginTransaction();
		void CommitTransaction();
	}
}
