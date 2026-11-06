namespace Rusoom.DTOs.PrivacyPolicy
{
    public class CurrentPrivacyPolicyDto
    {
        public required Guid PrivacyPolicyId { get; set; }
        public required int Version { get; set; }
        public required DateTimeOffset PublishedAtUtc { get; set; }
        public required string Locale { get; set; }
        public required string Content { get; set; }
    }
}