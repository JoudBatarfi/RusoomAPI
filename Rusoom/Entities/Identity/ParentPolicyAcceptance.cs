namespace Rusoom.Entities.Identity
{
    public class ParentPolicyAcceptance
    {
        public Guid ParentPolicyAcceptanceId { get; set; }
        public Guid ParentId { get; set; }
        public Guid PrivacyPolicyId { get; set; }
        public DateTimeOffset AcceptedAtUtc { get; set; }
        public string Locale { get; set; } = string.Empty;
    }
}