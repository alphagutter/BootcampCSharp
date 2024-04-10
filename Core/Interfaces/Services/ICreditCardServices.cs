
using Core.Models;
using Core.Requests.CreditCardModel;

namespace Core.Interfaces.Services;

public interface ICreditCardServices
{
    Task<List<CreditCardDTO>> GetFiltered(FiltersCreditCardModel filter);

    Task<CreditCardDTO> Add(CreateCreditCardModel model);
    Task<CreditCardDTO> GetById(int id);
    Task<CreditCardDTO> Update(UpdateCreditCardModel model);
    Task<bool> Delete(int id);
    Task<List<CreditCardDTO>> GetAll();
}
