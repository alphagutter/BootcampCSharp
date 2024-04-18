using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PetitionModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Security.Principal;

namespace Infrastructure.Repositories
{
    public class PetitionRepository : IPetitionRepository
    {
        private readonly BootcampContext _context;

        public PetitionRepository(BootcampContext context)
        {
            _context = context;
        }

        public async Task<PetitionDTO> Add(CreatePetitionRequest model)
        {
            var petition = model.Adapt<Petition>();
            _context.Petitions.Add(petition);
            await _context.SaveChangesAsync();

            var currency = await _context.Promotions.FindAsync(model.CurrencyId);
            var customer = await _context.Promotions.FindAsync(model.CustomerId);
            var bank = await _context.Customers.FindAsync();


            var petitionDTO = petition.Adapt<PetitionDTO>();
            return petitionDTO;
        }

        public async Task<PetitionDTO> GetById(int id)
        {
            var petition = await _context.Petitions
                .Include(p => p.Currency)
                .Include(p => p.Customer)
            .SingleOrDefaultAsync(p => p.Id == id);

            if (petition is null) throw new NotFoundByIdException("Petition", id);

            return petition.Adapt<PetitionDTO>();
        }
    }
}
