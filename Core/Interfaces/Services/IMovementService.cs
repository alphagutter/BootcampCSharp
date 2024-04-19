using Core.Models;
using Core.Requests.MovementModel;

namespace Core.Interfaces.Services;

public interface IMovementService
{
    Task<MovementDTO> Add(CreateMovementRequest request);
    Task<MovementDTO> GetById(int id);
}