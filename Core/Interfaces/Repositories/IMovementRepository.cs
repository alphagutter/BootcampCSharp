
using Core.Entities;
using Core.Models;
using Core.Requests.MovementModel;

namespace Core.Interfaces.Repositories;

public interface IMovementRepository
{
    Task<MovementDTO> GetById(int id);
    Task<MovementDTO> Add(CreateMovementRequest request);
}