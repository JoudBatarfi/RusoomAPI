namespace Rusoom.Entities.Children
{
    public class ChildAccess
    {
        public Guid ChildAccessId { get; set; }
        public Guid ParentId { get; set; }
        public Guid ChildId { get; set; }
        public ChildAccessRole Role { get; set; }
        public string? DisplayLabel { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;
    }

   
}
