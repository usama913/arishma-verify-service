using Microsoft.EntityFrameworkCore;
using Arishma.Verify.Domain;
namespace Arishma.Verify.Infrastructure;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Verification> Verifications => Set<Verification>();
    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Verification>().ToTable("verifications");
        base.OnModelCreating(b);
    }
}
