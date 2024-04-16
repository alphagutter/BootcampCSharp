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


    /// <summary>
    /// Adds a promotion object using the mapping configuration(search in Infrastructure/Mappings/PromotionMappingConfiguration.cs)
    /// </summary>
    public async Task<PromotionDTO> Add(CreatePromotionModel model)
    {

        var promotion = model.Adapt<Promotion>();

        //for every Id added to the model.EnterpriseIds, it will make the connection between the promotion and all enterprises
        foreach (int enterpriseId in model.EnterpriseIds)
        {
            var promotionEnterprise = new PromotionEnterprise
            {
                Promotion = promotion,
                EnterpriseId = enterpriseId
            };
            _context.PromotionEnterprise.Add(promotionEnterprise);
        }

        _context.Promotions.Add(promotion);

        await _context.SaveChangesAsync();

        var createdPromotion = await _context.Promotions
            .FirstOrDefaultAsync(a => a.Id == promotion.Id);


        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;

    }

    /// <summary>
    /// Deletes the object without hesitation
    /// </summary>
    public async Task<bool> Delete(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);
        if (promotion == null) { throw new NotFoundException($"Promotion with id: {id} not found"); }
        _context.Promotions.Remove(promotion);
        var result = await _context.SaveChangesAsync();
        return result > 0;

    }


    /// <summary>
    /// returns the promotion by Id
    /// </summary>
    public async Task<PromotionDTO> GetById(int id)
    {
        var query = _context.Promotions
           .Include(a => a.PromotionsEnterprises)
           .AsQueryable();

        var promotion = await _context.Promotions.FindAsync(id);

        var enterprise = await _context.Enterprises.ToListAsync();

        if (promotion is null)
            throw new NotFoundException($"Promotion with id: {id} not found");
        var result = await query.ToListAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;

    }



    /// <summary>
    /// Updates the promotion object
    /// </summary>
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

}