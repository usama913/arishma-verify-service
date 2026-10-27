namespace Arishma.Verify.Domain;
public class Verification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Value { get; set; } = "";
    public string Kind { get; set; } = "Email";
    public string Status { get; set; } = "Unknown";
}
