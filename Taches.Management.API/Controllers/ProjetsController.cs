using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Models;

namespace Taches.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetsController(IProjetService projetService) : ControllerBase
    {

        [HttpPost]
            public async Task<IActionResult> AddProjet(ProjetModel projet)
        {
            try
            {
               var result = await projetService.Add(projet);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest("failed to add Project");
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpDateProjet(ProjetModel projet)
        {
            try
            {
                var result = await projetService.Update(projet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to update Project");
            }
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteProjet([FromBody] int id)
        { 
            try
            {
                var res = await projetService.Delete(id);
                return Ok("projet deleted successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest("failed to delete Project");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjet()
        {
            try
            {
                var res = await projetService.All();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to fetch Projects");
            }
        }


        [HttpPost("one")]
        public async Task<IActionResult> GetOneProjet([FromBody] int id)
        {
            try
            {
                var res = await projetService.GetOne(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed to fetch Project");
            }
        }

        [HttpPost("OnLancer")]
        public async Task<IActionResult> OnLancer([FromBody] int ProjetId) {

            await projetService.OnLancer(ProjetId);

            return Ok();
        
        }

        [HttpPost("OnAnnuler")]
        public async Task<IActionResult> OnAnnuler([FromBody] int ProjetId)
        {

            await projetService.OnAnnuler(ProjetId);


            return Ok();
        }


        [HttpPost("OnDelancer")]
        public async Task<IActionResult> OnDelancer([FromBody] int ProjetId) {

            await projetService.OnDelancer(ProjetId);

            return Ok();
        }


        [HttpPost("OnValider")]
        public async Task<IActionResult> OnValider([FromBody] int ProjetId) {

            await projetService.OnValider(ProjetId);

            return Ok();
        }


        [HttpPost("OnInvalider")]
        public async Task<IActionResult> OnInvalider([FromBody] int ProjetId) {

            await projetService.OnInvalider(ProjetId);

            return Ok();
        }

        [HttpPost("OnReCree")]
        public async Task<IActionResult> OnReCree([FromBody] int ProjetId) {

            await projetService.OnReCree(ProjetId);

            return Ok();
        }

    }
}
