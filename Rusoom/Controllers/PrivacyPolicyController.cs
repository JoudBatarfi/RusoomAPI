using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Rusoom.Services.PrivacyPolicy;
using Rusoom.DTOs.PrivacyPolicy;


namespace Rusoom.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/privacy-policy")]
    public class PrivacyPolicyController : ControllerBase
    {

        private readonly IPrivacyPolicyService _privacyPolicyService;

        public PrivacyPolicyController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }

        [HttpGet("current")]
        public async Task<ActionResult<CurrentPrivacyPolicyDto>> GetCurrent([FromQuery] string locale, CancellationToken cancellationToken)
        {

            var policy = await _privacyPolicyService.GetCurrentPrivacyPolicyAsync(locale, cancellationToken);

            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

    }
}
