using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.MovementModel;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovementRepository : IMovementRepository
{

    private readonly BootcampContext _context;

    public MovementRepository(BootcampContext context)
    {
        _context = context;
    }

    public Task<MovementDTO> Add(CreateMovementRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<MovementDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }
}