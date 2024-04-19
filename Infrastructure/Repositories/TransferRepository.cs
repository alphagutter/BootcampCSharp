using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.MovementModel;
using Core.Requests.TransferModel;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TransferRepository : ITransferRepository
{
    private readonly BootcampContext _transfercontext;
    public TransferRepository(BootcampContext bootcampcontext)
    {
        _transfercontext = bootcampcontext;
    }

    public Task<TransferDTO> GetDestinationAccount(TransferRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TransferDTO> Transfer(TransferRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<TransferDTO> ValidateRequest(TransferRequest request)
    {
        throw new NotImplementedException();
    }

}