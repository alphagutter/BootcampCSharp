
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity.HasKey(e => e.Id).HasName("Transfer_pkey");

        entity
            .Property(e => e.Amount)
            .IsRequired();

        entity
            .Property(e => e.TransferredDateTime)
            .IsRequired();
        
        entity
            .Property(e => e.Description)
            .IsRequired();



        entity
            .HasOne(transfer => transfer.OriginAccount)
            .WithMany(srcAccount => srcAccount.Transfers)
            .HasForeignKey(transfer => transfer.OriginAccountId);

        entity
            .HasOne<Account>()
            .WithMany(destinationAccount => destinationAccount.Transfers)
            .HasForeignKey(transfer => transfer.DestinationAccountId);

        entity
            .HasOne(transfer => transfer.Bank)
            .WithMany(bank => bank.Transfers)
            .HasForeignKey(transfer => transfer.BankId);

        entity
            .HasOne(transfer => transfer.Currency)
            .WithMany(currency => currency.Transfers)
            .HasForeignKey(transfer => transfer.CurrencyId);
    }
}
