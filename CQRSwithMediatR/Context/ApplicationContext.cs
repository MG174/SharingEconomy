using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRSwithMediatR.Context
{
	public class ApplicationContext : DbContext, IApplicationContext
	{
		public DbSet<User> User { get; set; }
		public DbSet<Advertisment> Advertisment { get; set; }
		public DbSet<Booking> Booking { get; set; }
		public DbSet<Review> Review { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
		{

		}

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

		public async void BeginTransaction()
		{
			await base.Database.BeginTransactionAsync();
		}

		public async void CommitTransaction()
		{
			await base.Database.CommitTransactionAsync();
		}
	}
}
