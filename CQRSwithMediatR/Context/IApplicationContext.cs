using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Context
{
	public interface IApplicationContext
	{
		DbSet<Book> Books { get; set; }
		DbSet<User> User { get; set; }
		DbSet<Advertisment> Advertisment { get; set; }
		DbSet<Booking> Booking { get; set; }

		Task<int> SaveChangesAsync();
	}
}
