using kutyak.Models;
using kutyak.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kutyak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FajtaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFajta()
        {
            return StatusCode(StatusCodes.Status200OK, FajtaService.GetFajtak());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFajta(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = new Fajtum { Id = id };
                    context.Fajta.Remove(fajta);
                    //context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, "Fajta szavazójoga megvonva");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] string Json)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = JsonConvert.DeserializeObject<Fajtum>(Json);
                    context.Fajta.Update(fajta);
                    await context.SaveChangesAsync();
                    return Ok("A fajta adatainak a módosítása megtörtént sikeresen");
                }
                catch (Exception ex)
                {
                    return BadRequest("A fajta adatainak módosítása sikertelen!");
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string Json)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = JsonConvert.DeserializeObject<Fajtum>(Json);
                    context.Fajta.Add(fajta);
                    await context.SaveChangesAsync();
                    return Ok("A fajta adatainak a tárolása megtörtént sikeresen");
                }
                catch (Exception ex)
                {
                    return BadRequest("A fajta adatainak tárolása sikertelen!");
                }
            }

        }









    }
}
