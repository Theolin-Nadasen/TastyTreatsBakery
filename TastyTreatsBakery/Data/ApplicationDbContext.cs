using Microsoft.EntityFrameworkCore;
using TastyTreatsBakery.Models;

namespace TastyTreatsBakery.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Treat> treats {  get; set; }

    }
}
