
using Core.Models;
using Core.Requests.ExtractionModel;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IExtractionRepository
{
    Task<ExtractionDTO> Add(CreateExtractionRequest request);
    Task<ExtractionDTO> GetById(int id);
}
