using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Core.Requests.EnterpriseModel;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class EnterpriseService : IEnterpriseService
{
    private readonly IEnterpriseRepository _enterpriseRepository;

    public EnterpriseService(IEnterpriseRepository enterpriseRepository)
    {
        _enterpriseRepository = enterpriseRepository;
    }

    public async Task<EnterpriseDTO> Add(CreateEnterpriseModel model)
    {
        return await _enterpriseRepository.Add(model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _enterpriseRepository.Delete(id);
    }

    public async Task<EnterpriseDTO> GetById(int id)
    {
        return await _enterpriseRepository.GetById(id);
    }

    public async Task<EnterpriseDTO> Update(UpdateEnterpriseModel model)
    {
        return await _enterpriseRepository.Update(model);
    }

    // Not implemented yet
    public async Task<List<EnterpriseDTO>> GetFiltered(FiltersEnterpriseModel filter)
    {
        throw new NotImplementedException();
    }
}
