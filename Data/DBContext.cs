using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{
  public DBContext(DbContextOptions<DBContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
}