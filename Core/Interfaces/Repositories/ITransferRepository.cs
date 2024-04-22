
using Core.Entities;
using Core.Models;
using Core.Requests.TransferModel;


namespace Core.Interfaces.Repositories;

public interface ITransferRepository
{
    Task<TransferDTO> Transfer(TransferRequest request);
}
