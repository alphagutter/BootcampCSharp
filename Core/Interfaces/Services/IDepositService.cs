using Core.Models;
using Core.Requests.DepositModel;

namespace Core.Interfaces.Services;

public interface IDepositService
{
    Task<DepositDTO> Add(CreateDepositModel model);
    Task<DepositDTO> GetById(int id);
}
