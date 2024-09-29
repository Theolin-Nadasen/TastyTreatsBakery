using Microsoft.EntityFrameworkCore;
using TastyModels;

namespace TastData.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Treat> treats {  get; set; }

    }
}
