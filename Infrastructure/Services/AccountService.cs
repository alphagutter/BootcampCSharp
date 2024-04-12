using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.AccountModel;

namespace Infrastructure.Services
{
    /// <summary>
    /// Constructors from all the services to use in the Accounts Table
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AccountDTO>> GetFiltered(FiltersAccountModel filter)
        {
            return await _repository.GetFiltered(filter);
        }

        public async Task<AccountDTO> Add(CreateAccountModel model)
        {
            return await _repository.Add(model);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<AccountDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<AccountDTO> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<AccountDTO> Update(UpdateAccountModel model)
        {
            return await _repository.Update(model);
        }
    }
}
