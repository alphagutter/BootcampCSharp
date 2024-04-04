using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class SavingAccountConfiguration : IEntityTypeConfiguration<SavingAccount>
{
    public void Configure(EntityTypeBuilder<SavingAccount> entity)
    {
        entity.HasKey(e => e.Id).HasName("SavingAccount_pkey");



        entity.Property(SavingAccount => SavingAccount.HolderName).HasMaxLength(100);
        entity.Property(SavingAccount => SavingAccount.SavingType);



        entity
            .HasOne(SavingAccount => SavingAccount.Account)
            .WithMany(SavingAccount => SavingAccount.SavingAccounts)
            .HasForeignKey(SavingAccount => SavingAccount.Id);

    }
}