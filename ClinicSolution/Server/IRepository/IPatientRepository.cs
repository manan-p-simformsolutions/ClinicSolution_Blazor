using ClinicSolution.Shared.Appointment;
using ClinicSolution.Shared.Patient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IRepository
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetById(int id);
        Task<int> Create(Patient model);
        Task Update(Patient model);
        Task Delete(int id);
    }
}
