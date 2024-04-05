﻿using Core.Models;
using Core.Requests.BankModel;
using Core.Requests.CustomerModel;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter);

    /// <summary>
    /// not implemented yet
    /// </summary>
    Task<CustomerDTO> Add(CreateCustomerModel model);
    //Task<CustomerDTO> GetById(int id);
    //Task<CustomerDTO> Update(UpdateBankModel model);
    //Task<bool> Delete(int id);
}