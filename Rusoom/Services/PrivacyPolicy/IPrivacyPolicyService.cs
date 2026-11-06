using Rusoom.DTOs.PrivacyPolicy;

namespace Rusoom.Services.PrivacyPolicy
{
    public interface IPrivacyPolicyService
    {
        public Task<CurrentPrivacyPolicyDto?> GetCurrentPrivacyPolicyAsync(string locale, CancellationToken cancellationToken);
    }
}

