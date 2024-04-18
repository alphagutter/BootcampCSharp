using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.PetitionModel;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class PetitionService : IPetitionService
    {
        private readonly IPetitionRepository _petitionRepository;

        public PetitionService(IPetitionRepository petitionRepository)
        {
            _petitionRepository = petitionRepository;
        }

        public async Task<PetitionDTO> Add(CreatePetitionRequest model)
        {
            return await _petitionRepository.Add(model);
        }

        public async Task<PetitionDTO> GetById(int id)
        {
            return await _petitionRepository.GetById(id);
        }
    }
}
