using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.MovementModel;

namespace Infrastructure.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _movementRepository;

    public MovementService(IMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<MovementDTO> Add(CreateMovementRequest model)
    {
        return await _movementRepository.Add(model);
    }

    public async Task<MovementDTO> GetById(int id)
    {
        return await _movementRepository.GetById(id);
    }
}