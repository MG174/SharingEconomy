using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Context
{
	public interface IApplicationContext
	{
		DbSet<Book> Books { get;set; }

		Task<int> SaveChangesAsync();
	}
}
