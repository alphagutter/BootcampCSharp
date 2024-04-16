using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PromotionModel;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly BootcampContext _context;
    public PromotionRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<PromotionDTO> Add(CreatePromotionModel model)
    {
        var promotiontocreate = model.Adapt<Promotion>();
        _context.Promotions.Add(promotiontocreate);

        await _context.SaveChangesAsync();

        var promotionDTO = promotiontocreate.Adapt<PromotionDTO>();
        return promotionDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);
        if (promotion == null) { throw new NotFoundException($"Promotion with id: {id} not found"); }
        _context.Promotions.Remove(promotion);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<PromotionDTO> GetById(int id)
    {
        var query = _context.Promotions
           .Include(a => a.PromotionsEnterprises)
           .AsQueryable();

        var promotion = await _context.Promotions.FindAsync(id);

        if (promotion is null)
            throw new NotFoundException($"Promotion with id: {id} not found");
        var result = await query.ToListAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;
    }


    public async Task<PromotionDTO> Update(UpdatePromotionModel model)
    {
        var promotion = await _context.Promotions.FindAsync(model.Id);

        if (promotion is null) throw new Exception("Promotion was not found");

        model.Adapt(promotion);

        _context.Promotions.Update(promotion);

        await _context.SaveChangesAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();
        return promotionDTO;
    }

    //not implemented yet
    public async Task<List<PromotionDTO>> GetFiltered(FilterPromotionModel filter)
    {
        throw new NotImplementedException();
    }
}