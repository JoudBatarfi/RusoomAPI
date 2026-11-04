namespace Rusoom.Entities.Children
{
    public class Child
    {
        public Guid ChildId { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset? DeletedAtUtc { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;
    }
}
