
using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.CustomerModel;
using Core.Requests.ServiceModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for Service Creation(template to create Service and ServiceDTO)
/// </summary>
public class ServiceMappingConfiguration : IRegister

{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateServiceModel to Service)
        config.NewConfig<CreateServiceModel, Service>()
            .Map(dest => dest.Name, src => src.Name);
        
        //origin to destination(Service to ServiceDTO)
        config.NewConfig<Service, ServiceDTO>()
            .Map(dest => dest.Name, src => src.Name);


    }

}