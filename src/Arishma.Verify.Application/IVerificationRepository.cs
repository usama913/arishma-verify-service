namespace Arishma.Verify.Application;
public interface IVerificationRepository
{
    Task<IReadOnlyList<VerificationDto>> ListAsync(CancellationToken ct = default);
}
