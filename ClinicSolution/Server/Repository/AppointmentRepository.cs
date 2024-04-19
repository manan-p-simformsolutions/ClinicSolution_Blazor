using ClinicSolution.Server.Data;
using ClinicSolution.Server.IRepository;
using ClinicSolution.Shared.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDBContext _context;

        public AppointmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Appointment model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;

        }

        public async Task Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                throw new ArgumentException($"Appointment with ID {id} not found.");

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Appointment appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(appointment.Id);
            if (existingAppointment == null)
                throw new ArgumentException($"Appointment with ID {appointment.Id} not found.");

            _context.Entry(existingAppointment).CurrentValues.SetValues(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
