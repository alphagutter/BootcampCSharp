
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity
            .HasKey(e => e.Id).HasName("Product_pkey");


        entity.HasOne(p => p.Currency)
               .WithMany()
               .HasForeignKey(p => p.CurrencyId)
               .IsRequired();

        entity.HasOne(p => p.CreditCard)
               .WithOne()
               .HasForeignKey<CreditCard>(p => p.Id);

        entity.HasOne(p => p.CurrentAccount)
               .WithOne()
               .HasForeignKey<CurrentAccount>(p => p.Id);

        entity.HasOne(p => p.CreditOnly)
               .WithOne()
               .HasForeignKey<CreditOnly>(p => p.Id);
    }
}
