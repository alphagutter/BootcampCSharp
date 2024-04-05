using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Customer_pkey");

        entity
            .Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired();

        entity
            .Property(e => e.Lastname)
            .HasMaxLength(200);

        entity
            .Property(e => e.DocumentNumber)
            .HasMaxLength(200)
            .IsRequired();

        entity
            .Property(e => e.Address)
            .HasMaxLength(300);

        entity
            .Property(e => e.Mail)
            .HasMaxLength(200);

        entity
            .Property(e => e.Phone)
            .HasMaxLength(200);

        entity
            .HasOne(d => d.Bank)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.BankId);

        entity
            .HasMany(d => d.Accounts)
            .WithOne(p => p.Customer)
            .HasForeignKey(d => d.CustomerId);
    }
}