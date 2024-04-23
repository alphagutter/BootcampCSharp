
using Core.Models;
using Core.Requests.DepositModel;

namespace Core.Interfaces.Repositories;

public interface IDepositRepository
{
    Task<DepositDTO> Add(CreateDepositModel model);
    Task<DepositDTO> GetById(int id);
}
