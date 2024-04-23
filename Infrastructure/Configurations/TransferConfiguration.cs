
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> entity)
    {
        entity.HasKey(e => e.Id).HasName("Transfer_pkey");


        //entity
        //    .HasOne(transfer => transfer.OriginAccount)
        //    .WithMany(srcAccount => srcAccount.Transfers)
        //    .HasForeignKey(transfer => transfer.OriginAccountId);
    
        //entity
        //    .HasOne(transfer => transfer.OriginAccount)
        //    .WithMany(targetAccount => targetAccount.Transfers)
        //    .HasForeignKey(transfer => transfer.DestinationAccountId);
    }
}
