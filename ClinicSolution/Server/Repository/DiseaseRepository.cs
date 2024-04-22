using ClinicSolution.Server.Data;
using ClinicSolution.Server.IRepository;
using ClinicSolution.Shared.Disease;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Repository
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ApplicationDBContext _context;

        public DiseaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Disease model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task Delete(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
                throw new ArgumentException($"Disease with ID {id} not found.");

            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Disease>> GetAllDisease()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> GetById(int id)
        {
            return await _context.Diseases.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Update(Disease model)
        {
            var existingAppointment = await _context.Diseases.FindAsync(model.Id);
            if (existingAppointment == null)
                throw new ArgumentException($"Appointment with ID {model.Id} not found.");

            _context.Entry(existingAppointment).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
        }
    }
}
