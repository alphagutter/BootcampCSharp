
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.CreditCardModel;

namespace Infrastructure.Services;


/// <summary>
/// Constructors from all the services to use in the Credit Cards Table
/// </summary>
public class CreditCardService : ICreditCardServices
{
    private readonly ICreditCardRepository _repository;

    public CreditCardService(ICreditCardRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<CreditCardDTO>> GetFiltered(FiltersCreditCardModel filter)
    {
        return await _repository.GetFiltered(filter);
    }

    public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
    {

        return await _repository.Add(model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<List<CreditCardDTO>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<CreditCardDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<CreditCardDTO> Update(UpdateCreditCardModel model)
    {
        return await _repository.Update(model);
    }

}
