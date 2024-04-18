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
            .Property(r => r.Amount)
            .IsRequired();

        entity
            .Property(r => r.Term)
            .IsRequired();

        entity
            .HasOne(r => r.Currency)
            .WithMany(c => c.Petitions)
            .HasForeignKey(r => r.CurrencyId);
        entity
            .HasOne(r => r.Customer)
            .WithMany(c => c.Petitions)
            .HasForeignKey(r => r.CustomerId);
    }
}