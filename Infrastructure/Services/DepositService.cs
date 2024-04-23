
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.DepositModel;

namespace Infrastructure.Services;


/// <summary>
/// Constructors from all the services to use in the Deposits Table
/// </summary>
public class DepositService : IDepositService
{
    private readonly IDepositRepository _repository;


    public async Task<DepositDTO> Add(CreateDepositModel model)
    {

        return await _repository.Add(model);

    }

    public async Task<DepositDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }
}