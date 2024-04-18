
using Core.Models;
using Core.Requests.PetitionModel;

namespace Core.Interfaces.Repositories;

public interface IPetitionRepository
{
    //this task is the only that petition will have, the user will not be allowed to update its request

    Task<PetitionDTO> Add(CreatePetitionRequest request);
    Task<PetitionDTO> GetById(int id);


}
