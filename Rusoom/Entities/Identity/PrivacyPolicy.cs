namespace Rusoom.Entities.Identity
{
    public class PrivacyPolicy
    {
        public Guid PrivacyPolicyId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset PublishedAtUtc { get; set; } = DateTimeOffset.UtcNow;
        public bool IsCurrent { get; set; }
    }
}