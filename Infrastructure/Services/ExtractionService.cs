using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.ExtractionModel;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

/// <summary>
/// Constructors from all the services to use in the Extractions Table
/// </summary>
public class ExtractionService : IExtractionService
{
    private readonly IExtractionRepository _repository;

    public ExtractionService(IExtractionRepository extractionRepository)
    {
        _repository = extractionRepository;
    }

    public async Task<ExtractionDTO> Add(CreateExtractionRequest request)
    {
        return await _repository.Add(request);
    }

    public async Task<ExtractionDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }
}
