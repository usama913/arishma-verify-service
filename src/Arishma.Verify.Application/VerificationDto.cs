namespace Arishma.Verify.Application;
public record VerificationDto(Guid Id, string Name);
public record ServiceInfoDto(string Service, string Subdomain, string Status, string DatabaseProvider);
