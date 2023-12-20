using Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class UserContext : DbContext
{
  public UserContext(DbContextOptions<UserContext> options) : base(options)
  {}

  public DbSet<User> Users { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    // }
}