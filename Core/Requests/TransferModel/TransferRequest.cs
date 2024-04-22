﻿using Core.Constants;
using Core.Entities;

namespace Core.Requests.TransferModel;

public class TransferRequest
{
    public int OriginAccountId { get; set; }
    public int DestinationBankId { get; set; }
    public TransferType TransferType { get; set; }
    //it will not be necessary if the banks are the same for the origin and destination
    //only chargable if the bank is equal for origin and destination
    public int DestinationId { get; set; }
    public decimal Amount { get; set; }
    public string AccountNumber { get; set; } = string.Empty;   
    public string DocumentNumber { get; set; } = string.Empty;

    //public int OriginAccountId { get; set; }
    //public TransferType TransferType { get; set; }
    //public int DestinationBankId { get; set; }
    //public string AccountNumber { get; set; } = string.Empty;
    //public string DocumentNumber { get; set; } = string.Empty;
    //public int CurrencyId { get; set; }
    //public decimal Amount { get; set; }
}
