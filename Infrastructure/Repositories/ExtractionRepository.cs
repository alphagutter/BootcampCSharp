using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Requests.ExtractionModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExtractionRepository : IExtractionRepository
{
    private readonly BootcampContext _context;

    public ExtractionRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ExtractionDTO> Add(CreateExtractionRequest request)
    {
        var extraction = request.Adapt<Extraction>();

        _context.Extractions.Add(extraction);

        var originalAccount = await _context.Accounts.FindAsync(request.AccountId);

        if (originalAccount == null) throw new NotFoundByIdException("Account", request.AccountId);

        originalAccount.Balance -= request.Amount;

        await _context.SaveChangesAsync();

        var createExtraction = await _context.Extractions
            .FirstOrDefaultAsync(a => a.Id == extraction.Id);

        return createExtraction.Adapt<ExtractionDTO>();
    }

    public async Task<ExtractionDTO> GetById(int id)
    {
        var extraction = await _context.Extractions
            .Include(a => a.Account)
            .Include(a => a.Bank)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (extraction is null) throw new NotFoundByIdException("Extraction", id);

        return extraction.Adapt<ExtractionDTO>();
    }
}
