using ClinicSolution.Server.Data;
using ClinicSolution.Server.IRepository;
using ClinicSolution.Shared.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBContext _context;

        public PatientRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Patient model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                throw new ArgumentException($"Patient with ID {id} not found.");

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Patient model)
        {
            var existingpatient = await _context.Patients.FindAsync(model.Id);
            if (existingpatient == null)
                throw new ArgumentException($"Patient with ID {model.Id} not found.");

            _context.Entry(existingpatient).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
        }
    }
}
