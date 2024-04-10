using Core.Entities;
using Core.Models;
using Core.Constants;
using Core.Requests.CreditCardModel;
using Mapster;

namespace Infrastructure.Mappings;

/// <summary>
/// Configuration for CreditCard Creation(template to create CreditCard and CreditCardDTO)
/// </summary>
public class CreditCardMappingConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreateCreditCardModel to CreditCard)
        config.NewConfig<CreateCreditCardModel, CreditCard>()
            .Map(dest => dest.Designation, src => src.Designation)
            .Map(dest => dest.IssueDate, src => src.IssueDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.CardNumber, src => src.CardNumber)
            .Map(dest => dest.Cvv, src => src.Cvv)
            .Map(dest => dest.CreditCardStatus, src => Enum.Parse<CreditCardStatus>(src.CreditCardStatus))
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.CurrentDebt, src => src.CurrentDebt)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.CustomerId, src => src.CustomerId);


        //origin to destination(Currency to CurrencyDTO)

        config.NewConfig<CreditCard, CreditCardDTO>()
            .Map(dest => dest.Id , src => src.Id)
            .Map(dest => dest.Designation, src => src.Designation)
            .Map(dest => dest.IssueDate, src => src.IssueDate)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.CardNumber, src => src.CardNumber)
            .Map(dest => dest.Cvv, src => src.Cvv)
            .Map(dest => dest.CreditCardStatus, src => src.CreditCardStatus)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.CurrentDebt, src => src.CurrentDebt)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.Currency, src => src.CurrencyId)
            .Map(dest => dest.Customer, src => src.CustomerId)
            //we mask the digits of the credit card
            .Map(dest => dest.RestrictedCreditCard, src => MaskCreditCard(src.CardNumber));

    }


    //class to mask the digits of the credit card
    private string MaskCreditCard(string cardNumber)
    {
        if (cardNumber.Length >= 16)
        {
            string visibleDigits = cardNumber.Substring(cardNumber.Length - 4);
            string maskedDigits = new string('X', cardNumber.Length - 4);
            return maskedDigits + visibleDigits;
        }
        else
        {
            return cardNumber;
        }

    }


}
