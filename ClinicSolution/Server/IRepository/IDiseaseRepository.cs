using ClinicSolution.Shared.Disease;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.IRepository
{
    public interface IDiseaseRepository
    {
        Task<List<Disease>> GetAllDisease();
        Task<Disease> GetById(int id);
        Task<int> Create(Disease model);
        Task Update(Disease model);
        Task Delete(int id);
    }
}
