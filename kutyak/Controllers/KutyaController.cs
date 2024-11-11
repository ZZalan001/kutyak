using kutyak.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kutyak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KutyaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetKutya()
        {
            return StatusCode(StatusCodes.Status200OK, KutyaService.GetKutyak());
        }
    }
}
