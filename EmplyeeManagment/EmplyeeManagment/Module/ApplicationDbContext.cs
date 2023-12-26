using System;
using Microsoft.EntityFrameworkCore;

namespace EmplyeeManagment.Module
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Employee> Employee { get; set; }
	}
}

