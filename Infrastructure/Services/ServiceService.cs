
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.CreditCardModel;
using Core.Requests.ServiceModel;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;


/// <summary>
/// Constructors from all the services to use in the Services Table
/// </summary>
public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;

    public ServiceService(IServiceRepository context)
    {
        _repository = context;
    }

    public async Task<ServiceDTO> Add(CreateServiceModel model)
    {

        return await _repository.Add(model);
    }

    public async Task<ServiceDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }
}