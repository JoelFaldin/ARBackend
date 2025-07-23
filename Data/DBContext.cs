using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{
  public DBContext(DbContextOptions<DBContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Times> Times { get; set; }
}