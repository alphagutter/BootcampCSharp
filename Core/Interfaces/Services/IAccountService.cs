using Core.Models;
using Core.Requests.AccountModel;


namespace Core.Interfaces.Services;
public interface IAccountService
{
    Task<List<AccountDTO>> GetFiltered(FiltersAccountModel filter);


    Task<AccountDTO> Add(CreateAccountRequest model);
    Task<AccountDTO> GetById(int id);
    Task<AccountDTO> Update(UpdateAccountModel model);
    Task<bool> Delete(int id);
    Task<List<AccountDTO>> GetAll();
}
