
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;


///<remarks>
///Configuration for the Deposit class
///</remarks>
public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> entity)
    {
        //primary key
        entity
            .HasKey(e => e.Id)
            .HasName("Deposit_pkey");


        //foreign key with account
        entity
            .HasOne(d => d.Account)
            .WithMany(a => a.Deposits)
            .HasForeignKey(d => d.AccountId)
            .IsRequired();

        entity
            .HasOne(deposit => deposit.Bank)
            .WithMany(bank => bank.Deposits)
            .HasForeignKey(deposit => deposit.BankId);

    }

}