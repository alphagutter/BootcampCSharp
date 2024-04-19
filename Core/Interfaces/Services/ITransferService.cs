
using Core.Models;
using Core.Requests.TransferModel;

namespace Core.Interfaces.Services;

public interface ITransferService
{
    Task<TransferDTO> Transfer(TransferRequest request);
    Task<TransferDTO> ValidateRequest(TransferRequest request);
    Task<TransferDTO> GetDestinationAccount(TransferRequest request);
    

}
