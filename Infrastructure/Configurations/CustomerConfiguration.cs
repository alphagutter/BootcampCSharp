using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {

        ///categorized by int type
        entity
            .HasKey(e => e.Id).HasName("Customer_pkey");

        ///categorized by string type
        entity.Property(Customer => Customer.Name).HasMaxLength(100).IsRequired();
        entity.Property(Customer => Customer.Lastname).HasMaxLength(100);
        entity.Property(Customer => Customer.DocumentNumber).HasMaxLength(100).IsRequired();
        entity.Property(Customer => Customer.Address).HasMaxLength(100);
        entity.Property(Customer => Customer.Mail).HasMaxLength(100);
        entity.Property(Customer => Customer.Phone).HasMaxLength(100);


        ///categorized by objects
        entity
            .HasOne(Bank => Bank.Bank)
            .WithMany(Bank => Bank.Customers)
            .HasForeignKey(bank => bank.Id);


    }
}