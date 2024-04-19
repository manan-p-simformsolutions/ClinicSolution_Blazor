using ClinicSolution.Shared.Disease;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IService
{
    public interface IDiseaseService
    {
        Task<List<Disease>> GetAllDisease();
        Task<Disease> GetDiseaseById(int id);
        Task<int> CreateDisease(Disease model);
        Task UpdateDisease(Disease model);
        Task DeleteDisease(int id);
    }
}
