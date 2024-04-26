
using Core.Entities;
using Core.Models;
using Core.Requests.PaymentModel;
using Mapster;

namespace Infrastructure.Mappings;

public class PaymentMappingConfiguration : IRegister

{
    public void Register(TypeAdapterConfig config)
    {
        //origin to destination(CreatePaymentRequest to Payment)
        config.NewConfig<CreatePaymentRequest, Payment>()
            .Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.OriginAccountId, src => src.OriginAccountId)
            .Map(dest => dest.PaymentDateTime, src => DateTime.Now)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.ServiceId, src => src.ServiceId);

        config.NewConfig<Payment, PaymentDTO>()
            .Map(dest => dest.DocumentNumber, src => src.DocumentNumber)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.OriginAccountDTO, src => src.OriginAccount)
            .Map(dest => dest.PaymentDateTime, src => src.PaymentDateTime)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.ServiceDTO, src => src.Service);






    }
}
