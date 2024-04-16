﻿
using Core.Models;
using Core.Requests.PromotionModel;

namespace Core.Interfaces.Repositories;

public interface IPromotionRepository
{
    Task<List<PromotionDTO>> GetFiltered(FilterPromotionModel filter);
    Task<PromotionDTO> GetById(int id);
    Task<PromotionDTO> Add(CreatePromotionModel model);
    Task<PromotionDTO> Update(UpdatePromotionModel model);
    Task<bool> Delete(int id);
}