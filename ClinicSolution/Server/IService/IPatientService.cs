using ClinicSolution.Shared.Patient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IService
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<int> CreatePatientInfo(Patient model);
        Task UpdatePatientInfo(Patient model);
        Task DeletePatientInfo(int id);
    }
}
