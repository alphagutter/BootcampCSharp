
using Core.Models;
using Core.Requests.ServiceModel;

namespace Core.Interfaces.Services;
public interface IServiceService
{
    Task<ServiceDTO> Add(CreateServiceModel model);
    Task<ServiceDTO> GetById(int id);
}

