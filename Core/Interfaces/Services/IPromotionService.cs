﻿using Core.Models;
using Core.Requests.PromotionModel;

namespace Core.Interfaces.Services;

public interface IPromotionService
{
    Task<PromotionDTO> Add(CreatePromotionModel model);
    Task<PromotionDTO> GetById(int id);
    Task<PromotionDTO> Update(UpdatePromotionModel model);
    Task<bool> Delete(int id);
}