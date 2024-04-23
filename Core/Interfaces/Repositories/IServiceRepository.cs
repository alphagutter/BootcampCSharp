
using Core.Models;
using Core.Requests.ServiceModel;

namespace Core.Interfaces.Repositories;

public interface IServiceRepository
{
    Task<ServiceDTO> Add(CreateServiceModel model);
    Task<ServiceDTO> GetById(int id);
}
