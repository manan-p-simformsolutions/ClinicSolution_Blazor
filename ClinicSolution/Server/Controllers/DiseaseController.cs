using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSolution.Server.Data;
using ClinicSolution.Shared.Disease;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DiseaseController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var diseases = await _context.tblDiseases.ToListAsync();
            return Ok(diseases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var disease = await _context.tblDiseases.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(disease);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Disease disease)
        {
            _context.Add(disease);
            await _context.SaveChangesAsync();
            return Ok(disease.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Disease disease)
        {
            _context.Entry(disease).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var disease = new Disease { Id = id };
            _context.Remove(disease);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
