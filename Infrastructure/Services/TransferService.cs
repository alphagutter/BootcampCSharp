
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.TransferModel;
using Microsoft.AspNetCore.Http.Features;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{

    private readonly ITransferRepository _repository;

    public TransferService(ITransferRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransferDTO> Transfer(TransferRequest request)
    {
        return await _repository.Transfer(request);
    }

}
