
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;


///<remarks>
///Configuration for the Payment class
///</remarks>
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity
            .HasKey(p => p.Id)
            .HasName("payment_pkey");


        //relation with origin account
        entity
            .HasOne(p => p.OriginAccount)
            .WithMany(a => a.Payments)
            .HasForeignKey(p => p.OriginAccountId);

        //relation with service
        entity
            .HasOne(p => p.Service)
            .WithMany(s => s.Payments)
            .HasForeignKey(p => p.ServiceId);

    }

}