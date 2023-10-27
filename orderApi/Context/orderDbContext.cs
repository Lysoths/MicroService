
using Microsoft.EntityFrameworkCore;
using orderApi.Models;

namespace basketApi.Context
{
	public class orderDbContext :Microsoft.EntityFrameworkCore.DbContext
	{
		public orderDbContext() : base() { }
		public orderDbContext(DbContextOptions<DbContext> options) : base(options) { }
		public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql("User ID=root;Password=root;Host=localhost;Port=5432;Database=Emarket;");
        }


    }
}
