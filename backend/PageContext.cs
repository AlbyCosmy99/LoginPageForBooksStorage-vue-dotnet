using System;

public class PageContext : DbContext
{
    public PageContext() : base("pagedb") { } 
	{
		public DbSet<User> Users { get; set; }
	}
}
