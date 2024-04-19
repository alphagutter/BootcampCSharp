using Core.Constants;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PetitionConfiguration : IEntityTypeConfiguration<Petition>
{
    public void Configure(EntityTypeBuilder<Petition> entity)
    {
        entity
            .HasKey(r => r.Id)
            .HasName("Petition_pkey");

        entity
            .HasOne(petition => petition.Currency)
            .WithMany(currency => currency.Petitions)
            .HasForeignKey(petitions => petitions.CurrencyId);
        entity
            .HasOne(petition => petition.Customer)
            .WithMany(customer => customer.Petitions)
            .HasForeignKey(petitions => petitions.CustomerId);

        entity
            .HasOne(petition => petition.Product)
            .WithMany(product => product.Petitions)
            .HasForeignKey(petitions => petitions.ProductId);
    }
}