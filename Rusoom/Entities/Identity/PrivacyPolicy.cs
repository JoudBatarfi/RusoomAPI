namespace Rusoom.Entities.Identity
{
    public class PrivacyPolicy
    {
        public Guid PrivacyPolicyId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset PublishedAtUtc { get; set; } = DateTimeOffset.UtcNow;
        public bool IsCurrent { get; set; }
        public string UrlEN { get; set; } = string.Empty;
        public string UrlAR { get; set; } = string.Empty;
        public string ContentHash { get; set; } = string.Empty;
    }
}