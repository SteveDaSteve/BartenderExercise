using Microsoft.EntityFrameworkCore;

namespace BartenderExercise.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		
		public DbSet<Models.Drink> Drinks { get; set; }
		public DbSet<Models.Order> Orders { get; set; }
	}
}
