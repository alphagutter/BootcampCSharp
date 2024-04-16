using Core.Models;
using Core.Requests.BusinessModel;

namespace Core.Interfaces.Services;

public interface IBusinessService
{
    Task<List<BusinessDTO>> GetFiltered(FiltersBusinessModel filter);
    Task<BusinessDTO> Add(CreateBusinessModel model);
    Task<BusinessDTO> GetById(int id);
    Task<BusinessDTO> Update(UpdateBusinessModel model);
    Task<bool> Delete(int id);
}