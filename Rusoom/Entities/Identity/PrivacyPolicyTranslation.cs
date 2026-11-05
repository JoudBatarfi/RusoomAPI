namespace Rusoom.Entities.Identity
{
    public class PrivacyPolicyTranslation
    {
        public Guid PrivacyPolicyTranslationId { get; set; }
        public Guid PrivacyPolicyId { get; set; }
        public string Locale { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ContentHash { get; set; } = string.Empty;
    }
}