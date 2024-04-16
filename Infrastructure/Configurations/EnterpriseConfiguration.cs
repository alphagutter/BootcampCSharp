using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
{
    public void Configure(EntityTypeBuilder<Enterprise> entity)
    {
        //primary key for 'Enterprise' table
        entity
            .HasKey(e => e.Id)
            .HasName("Enterprise_pkey"); 


        entity
            .Property(e => e.Name)
            .HasMaxLength(100).IsRequired();

        entity
            .Property(e => e.Address)
            .HasMaxLength(100);

        entity
            .Property(e => e.Phone)
            .HasMaxLength(100);
        entity
            .Property(e => e.Email)
            .HasMaxLength(100);


        //foreign key relation between Enterprise and PromotionsEnterprises (1:N)
        entity
            .HasMany(e => e.PromotionsEnterprises)
            .WithOne(pe => pe.Enterprise)
            .HasForeignKey(e => e.EnterpriseId);

    }
}