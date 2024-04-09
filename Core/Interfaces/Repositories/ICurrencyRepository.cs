
using Core.Models;
using Core.Requests.CurrencyModel;

namespace Core.Interfaces.Repositories;

public interface ICurrencyRepository
{
    //only filter by name
    Task<List<CurrencyDTO>> GetFiltered(FiltersCurrencyModel filter);

    Task<CurrencyDTO> Add(CreateCurrencyModel model);
    Task<CurrencyDTO> GetById(int id);
    Task<CurrencyDTO> Update(UpdateCurrencyModel model);
    Task<bool> Delete(int id);
    Task<List<CurrencyDTO>> GetAll();

}
