
using Core.Models;
using Core.Models.AccountTypes;
using Core.Requests.AccountModel;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<List<AccountDTO>> GetFiltered(FiltersAccountModel filter);


    Task<AccountDTO> Add(CreateAccountRequest model);
    Task<AccountDTO> GetById(int id);
    Task<AccountDTO> Update(UpdateAccountModel model);
    Task<bool> Delete(int id);
    Task<List<AccountDTO>> GetAll();
}
