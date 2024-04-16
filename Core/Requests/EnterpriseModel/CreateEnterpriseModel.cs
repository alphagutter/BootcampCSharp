﻿

using Core.Entities;

namespace Core.Requests.EnterpriseModel;
public class CreateEnterpriseModel
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; } = null;

}