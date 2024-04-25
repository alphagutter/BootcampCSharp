
using Core.Entities;
using Core.Models;
using Core.Requests.ExtractionModel;

namespace Core.Interfaces.Repositories;

public interface IExtractionService
{
    Task<ExtractionDTO> Add(CreateExtractionRequest request);
    Task<ExtractionDTO> GetById(int id);
}
