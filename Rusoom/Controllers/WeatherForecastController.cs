using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace Rusoom.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class PrivacyPolicyController : ControllerBase
    {
       
    }
}
