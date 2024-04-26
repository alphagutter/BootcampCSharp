using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity
            .HasKey(p => p.Id)
            .HasName("Product_pkey");

        entity
            .Property(p => p.Name)
            .IsRequired();

        entity
            .HasMany(product => product.Petitions)
            .WithOne(petition => petition.Product)
            .HasForeignKey(applicationForm => applicationForm.ProductId);
    }
}