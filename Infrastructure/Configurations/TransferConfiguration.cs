
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
            .HasMany(transfer => transfer.AccountTransfers)
            .WithOne(accounttransfers => accounttransfers.Transfer)
            .HasForeignKey(account => account.TransferId);
    }
}
