using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Context
{
	public class ApplicationContext : DbContext, IApplicationContext
	{
		public DbSet<Book> Books { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
		{

		}

		// W naszym przykładowym API trzymamy się konwencji
		// ze zdefiniowaniem connection-string w metodzie OnConfiguring
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite("Data Source=CQRSwithMediator.db");
			}
		}
		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}
	}
}
