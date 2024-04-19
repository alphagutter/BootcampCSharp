
using Core.Models;
using Core.Requests.MovementModel;

namespace Core.Interfaces.Repositories;

public interface IMovementRepository
{
    Task<MovementDTO> Add(CreateMovementRequest request);
    Task<MovementDTO> GetById(int id);
}