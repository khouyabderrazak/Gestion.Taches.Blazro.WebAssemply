using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Models;

namespace Taches.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TachesController(ITacheService tacheService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddTache(TacheModel tache)
        {
            try
            {
                var result = await tacheService.Add(tache);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to add tache");
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpDateTache(TacheModel projet)
        {
            try
            {
                var result = await tacheService.Update(projet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to update tache");
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteTache([FromBody] int id)
        {
            try
            {
                var res = await tacheService.Delete(id);
                return Ok("tache deleted successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest("failed to delete tache");
            }
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAllTaches([FromBody] int projetId)
        {
            try
            {
                var res = await tacheService.All(projetId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to fetch taches");
            }
        }


        [HttpPost("one")]
        public async Task<IActionResult> GetOneTache([FromBody] int id)
        {
            try
            {
                var res = await tacheService.GetOne(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to fetch Project");
            }
        }
    }
}
