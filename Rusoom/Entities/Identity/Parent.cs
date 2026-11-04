using Microsoft.AspNetCore.Identity;

namespace Rusoom.Entities.Identity
{
	public class Parent : IdentityUser<Guid>
	{

		public string Name { get; set; } = string.Empty;
		public string? CountryCode { get; set; }
		public string? Timezone { get; set; }
		public string? Locale { get; set; }
		public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;
	}
}