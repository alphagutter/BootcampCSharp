﻿
namespace Core.Models;


//can find validations on CreateCurrencyModel
public class CurrencyDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BuyValue { get; set; }
    public decimal SellValue { get; set; }
}
