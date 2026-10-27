using Arishma.Verify.Application;
namespace Arishma.Verify.Infrastructure;
public class EfVerificationRepository : IVerificationRepository
{
    private readonly AppDbContext _db;
    public EfVerificationRepository(AppDbContext db) => _db = db;
    // Phase 0: scaffold returns no rows and never requires a live DB for /health.
    // Phase 1: replace with a real query over _db.Verifications.
    public Task<IReadOnlyList<VerificationDto>> ListAsync(CancellationToken ct = default)
        => Task.FromResult<IReadOnlyList<VerificationDto>>(Array.Empty<VerificationDto>());
}
