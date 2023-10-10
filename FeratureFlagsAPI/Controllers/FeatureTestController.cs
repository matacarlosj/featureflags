using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace FeratureFlagsAPI.Controllers
{
    [FeatureGate(FeatureFlags.UseNewController)]
    [ApiController]
    [Route("[controller]")]
    public class FeatureTestController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok("Up");
        }
    }
}
