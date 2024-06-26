﻿using Core.Models;

namespace Core.Requests.CustomerModel;

public class UpdateCustomerModel
{
    public int Id { get; set; }  
    public string Name { get; set; }            = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; }  = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    
    public string CustomerStatus { get; set; }  = string.Empty;
    public DateTime? Birth { get; set; }
}
