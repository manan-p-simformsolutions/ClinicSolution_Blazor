using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSolution.Server.Data;
using ClinicSolution.Shared.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AppointmentController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var appointments = await _context.tblAppointments.ToListAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var appointment = await _context.tblAppointments.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = new Appointment { Id = id };
            _context.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
