using ClinicSolution.Server.IRepository;
using ClinicSolution.Server.IService;
using ClinicSolution.Shared.Disease;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicSolution.Server.Service
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseaseService(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        public async Task<int> CreateDisease(Disease model)
        {
            return await _diseaseRepository.Create(model);
        }

        public async Task DeleteDisease(int id)
        {
            await _diseaseRepository.Delete(id);
        }

        public async Task<List<Disease>> GetAllDisease()
        {
            return await _diseaseRepository.GetAllDisease();
        }

        public async Task<Disease> GetDiseaseById(int id)
        {
            return await _diseaseRepository.GetById(id);
        }

        public async Task UpdateDisease(Disease model)
        {
            await _diseaseRepository.Update(model);
        }
    }
}
