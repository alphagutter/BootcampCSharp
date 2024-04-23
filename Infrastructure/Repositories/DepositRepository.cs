using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.DepositModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Core.Exceptions;

namespace Infrastructure.Repositories;

public class DepositRepository : IDepositRepository
{
    private readonly BootcampContext _depositContext;

    public DepositRepository(BootcampContext bootcampContext)
    {
        _depositContext = bootcampContext;
    }

    public async Task<DepositDTO> Add(CreateDepositModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<DepositDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }
}