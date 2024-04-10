
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;


///<remarks>
///Configuration for the CreditCard class
///</remarks>
public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> entity)
    {
       //primary key
        entity
            .HasKey(e => e.Id)
            .HasName("CreditCard_pkey");

        //Designation (the text that will show in the credit card)
        entity
            .Property(e => e.Designation)
            .HasMaxLength(100)
            .IsRequired();


        entity
            .Property(e => e.IssueDate)
            .HasMaxLength(100);

        entity
            .Property(e => e.ExpirationDate)
            .HasMaxLength(100);


        entity
            .Property(e => e.CardNumber)
            .HasMaxLength(20)
            .IsRequired();


        //security number 
        entity
            .Property(e => e.Cvv)
            .HasMaxLength (10)
            .IsRequired();

        entity
            .Property (e => e.CreditLimit)
            .HasPrecision (20, 5)
            .IsRequired();

        entity
            .Property (e => e.AvailableCredit)
            .HasPrecision(20, 5)
            .IsRequired();
        entity
            .Property(e => e.CurrentDebt)
            .HasPrecision(20, 5);

        entity
            .Property(e => e.InterestRate)
            .HasPrecision (20, 5)
            .IsRequired();



        ///foreign keys


        //fk for currency
        entity
            .HasOne(creditcard => creditcard.Currency)
            .WithMany(currency => currency.CreditCards)
            .HasForeignKey(creditcard => creditcard.CurrencyId);

        //fk for customer
        entity
            .HasOne (creditcard => creditcard.Customer)
            .WithMany(currency => currency.CreditCards)
            .HasForeignKey(creditcard => creditcard.CustomerId);

    }

}
