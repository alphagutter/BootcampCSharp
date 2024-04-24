using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configurations;

///<remarks>
///Configuration for the Account class
///</remarks>
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> entity)
    {
        //key for account
        entity.HasKey(e => e.Id).HasName("Account_pkey");
        entity.Property(e => e.Number).HasMaxLength(100);
        entity.Property(e => e.Balance).HasPrecision(20, 5);

        //foreign key relation with currency table
        entity
            .HasOne(account => account.Currency)
            .WithMany(currency => currency.Accounts)
            .HasForeignKey(account => account.CurrencyId);
        //foreign key relation with customer table
        entity
            .HasOne(account => account.Customer)
            .WithMany(customer => customer.Accounts)
            .HasForeignKey(account => account.CustomerId);

        entity
            .HasOne(account => account.SavingAccount)
            .WithOne(savingAccount => savingAccount.Account)
            .HasForeignKey<SavingAccount>(savingAccount => savingAccount.AccountId);

        entity
            .HasOne(account => account.CurrentAccount)
            .WithOne(currentAccount => currentAccount.Account)
            .HasForeignKey<CurrentAccount>(savingAccount => savingAccount.AccountId);

        entity
            .HasMany(account => account.Transfers)
            .WithOne(transfer => transfer.OriginAccount)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        entity
            .HasMany(account => account.Payments)
            .WithOne(paymentService => paymentService.OriginAccount)
            .HasForeignKey(paymentService => paymentService.OriginAccountId);

        entity
            .HasMany(account => account.Deposits)
            .WithOne(deposit => deposit.Account)
            .HasForeignKey(deposit => deposit.AccountId);


    }
}
