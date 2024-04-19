using System;
using System.Threading.Tasks;
using ClinicSolution.Server.IService;
using ClinicSolution.Shared.Disease;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiseases()
        {
            try
            {
                var diseases = await _diseaseService.GetAllDisease();
                return Ok(diseases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiseaseById(int id)
        {
            try
            {
                var disease = await _diseaseService.GetDiseaseById(id);
                if (disease == null)
                    return NotFound();

                return Ok(disease);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDisease(Disease disease)
        {
            try
            {
                var id = await _diseaseService.CreateDisease(disease);
                return CreatedAtAction(nameof(GetDiseaseById), new { id }, disease);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisease(int id, Disease disease)
        {
            try
            {
                if (id != disease.Id)
                    return BadRequest("Disease ID mismatch");

                await _diseaseService.UpdateDisease(disease);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            try
            {
                await _diseaseService.DeleteDisease(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
