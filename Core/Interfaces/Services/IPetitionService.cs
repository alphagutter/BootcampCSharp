
using Core.Models;
using Core.Requests.PetitionModel;

namespace Core.Interfaces.Services;

public interface IPetitionService
{
    Task<PetitionDTO> Add(CreatePetitionRequest model);
    Task<PetitionDTO> GetById(int id);
}