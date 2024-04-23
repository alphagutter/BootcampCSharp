using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.ServiceModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly BootcampContext _context;

    public ServiceRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ServiceDTO> Add(CreateServiceModel model)
    {
        //searchs for the mapping configuration
        var servicetocreate = model.Adapt<Service>();

        _context.Services.Add(servicetocreate);

        await _context.SaveChangesAsync();

        //adaptation

        var serviceDTO = servicetocreate.Adapt<ServiceDTO>();


        return serviceDTO;
    }

    public async Task<ServiceDTO> GetById(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service is null) throw new NotFoundByIdException("Service", id);

        //adapting serviceDTO

        var serviceDTO = service.Adapt<ServiceDTO>();

        return serviceDTO;
    }
}