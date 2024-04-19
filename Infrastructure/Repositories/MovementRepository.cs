using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.MovementModel;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly BootcampContext _context;

    public MovementRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<MovementDTO> Add(CreateMovementRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<MovementDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }
}