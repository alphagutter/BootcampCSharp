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


        //if there's no promotion with that name, it will call this exception
        if (promotion == null) throw new NotFoundByIdException("Promotion", id);

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
        
        //if there's no promotion with that name, it will call this exception
        if (promotion is null) throw new NotFoundByIdException("Promotion", id);


        var enterprise = await _context.Enterprises.ToListAsync();

        var result = await query.ToListAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;

    }



    /// <summary>
    /// Updates the promotion object
    /// </summary>
    public async Task<PromotionDTO> Update(UpdatePromotionModel model)
    {
        //Retrieve the promotion from the database using the provided id
        var promotion = await _context.Promotions.FindAsync(model.Id);
        var enterprises = await _context.Enterprises.ToListAsync();

        if (promotion == null) throw new NotFoundByIdException("Promotion", model.Id);

        promotion.Adapt(model);

        //for every Id added to the model.EnterpriseIds, it will make the connection between the promotion and all enterprises
        foreach (int enterpriseId in model.EnterprisesIdsToAdd)
        {
            var promotionEnterprise = new PromotionEnterprise
            {
                Promotion = promotion,
                EnterpriseId = enterpriseId
            };
            _context.PromotionEnterprise.Add(promotionEnterprise);

        }

        //Remove the connections that are present in the model.EnterpriseIdsToDelete list
        foreach (int enterpriseId in model.EnterprisesIdsToDelete)
        {
            var promotionEnterprise = promotion.PromotionsEnterprises.SingleOrDefault(pe => pe.PromotionId == promotion.Id && pe.EnterpriseId == enterpriseId);
            if (promotionEnterprise != null)
                _context.PromotionEnterprise.Remove(promotionEnterprise);
        }

        await _context.SaveChangesAsync();



        //Return the updated promotion as a DTO
        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;
    }

}