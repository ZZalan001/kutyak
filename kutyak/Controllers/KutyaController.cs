using kutyak.Models;
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

        [HttpDelete("{id}")]
        public IActionResult DeleteKutya(int id)
        {
            using(var context = new KutyakContext())
            {
                try
                {
                    Kutya kutya = new Kutya { Id = id };
                    context.Kutyas.Remove(kutya);
                    //context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, "Kutya szavazójoga megvonva");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
