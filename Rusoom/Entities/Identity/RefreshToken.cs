namespace Rusoom.Entities.Identity
{
    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }
        public Guid ParentId { get; set; }
        public Guid FamilyId { get; set; }
        public Guid? ReplacedById { get; set; }
        public string TokenHash { get; set; } = string.Empty;
        public string? DeviceLabel { get; set; }
        public DateTimeOffset ExpiresAtUtc { get; set; }
        public DateTimeOffset? RevokedAtUtc { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;
    }
}