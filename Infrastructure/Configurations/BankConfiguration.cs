using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> entity)
    {

        ///categorized by int type
        entity
            .HasKey(e => e.Id).HasName("Bank_pkey");

        ///categorized by string type
        entity.Property(e => e.Name).HasMaxLength(100);
        entity.Property(e => e.Phone).HasMaxLength(20);
        entity.Property(e => e.Mail).HasMaxLength(100);
        entity.Property(e => e.Address).HasMaxLength(255);


        ///categorized by collections
        entity
            .HasMany(Bank => Bank.Customers)
            .WithOne(Bank => Bank.Bank)
            .HasForeignKey(bank => bank.Id);

    }
}
