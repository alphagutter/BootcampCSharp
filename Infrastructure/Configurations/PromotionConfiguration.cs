using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> entity)
    {
        //primary key for 'Promotion' table

        entity
            .HasKey(e => e.Id)
            .HasName("Promotion_pkey");

        entity
            .Property(p => p.Start)
            .IsRequired();

        entity
            .Property(p => p.End)
            .IsRequired();

        entity
            .Property(p => p.Discount)
            .IsRequired();


        //foreign key relation between Promotion and PromotionsEnterprises (1:N)
        entity
            .HasMany(p => p.PromotionsEnterprises)
            .WithOne(pe => pe.Promotion)
            .HasForeignKey(pe => pe.PromotionId);
    }

}
