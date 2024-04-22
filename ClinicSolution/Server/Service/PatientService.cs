using ClinicSolution.Server.IRepository;
using ClinicSolution.Server.IService;
using ClinicSolution.Shared.Patient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<int> CreatePatientInfo(Patient model)
        {
            return await _patientRepository.Create(model);
        }

        public async Task DeletePatientInfo(int id)
        {
            await _patientRepository.Delete(id);
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepository.GetById(id);
        }

        public async Task UpdatePatientInfo(Patient model)
        {
           await _patientRepository.Update(model);
        }
    }
}
