using Microsoft.EntityFrameworkCore;
using Rusoom.DTOs.PrivacyPolicy;
using Rusoom.Infrastructure.Data;


namespace Rusoom.Services.PrivacyPolicy
{
	public class PrivacyPolicyService : IPrivacyPolicyService
	{

		private readonly RusoomDbContext _rusoomDbContext;

		public PrivacyPolicyService(RusoomDbContext rusoomDbContext)
		{
			_rusoomDbContext = rusoomDbContext;
		}


		public async Task<CurrentPrivacyPolicyDto?> GetCurrentPrivacyPolicyAsync(string locale, CancellationToken cancellationToken)
		{

			var query = from policy in _rusoomDbContext.PrivacyPolicies
						join translation in _rusoomDbContext.PrivacyPolicyTranslations
						on policy.PrivacyPolicyId equals translation.PrivacyPolicyId
						where policy.IsCurrent && translation.Locale == locale
						select new CurrentPrivacyPolicyDto
						{
							PrivacyPolicyId = policy.PrivacyPolicyId,
							Version = policy.Version,
							PublishedAtUtc = policy.PublishedAtUtc,
							Locale = translation.Locale,
							Content = translation.Content
						};

			return await query.SingleOrDefaultAsync(cancellationToken);
		}

	}
}

