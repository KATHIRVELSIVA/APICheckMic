using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserModel> User { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<AdminModel> Admin { get; set; } = default!;

    }
}
