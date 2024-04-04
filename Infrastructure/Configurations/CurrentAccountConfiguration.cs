using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CurrentAccountConfiguration : IEntityTypeConfiguration<CurrentAccount>
{
    public void Configure(EntityTypeBuilder<CurrentAccount> entity)
    {
        entity.HasKey(e => e.Id).HasName("CurrentAccount_pkey");


        entity.Property(CurrentAccount => CurrentAccount.OperationalLimit).HasPrecision(20, 5);
        entity.Property(CurrentAccount => CurrentAccount.MonthAverage).HasPrecision(20, 5);
        entity.Property(CurrentAccount => CurrentAccount.Interest).HasPrecision(20, 5);



        entity
            .HasOne(CurrentAccount => CurrentAccount.Account)
            .WithMany(CurrentAccount => CurrentAccount.CurrentAccounts)
            .HasForeignKey(CurrentAccount => CurrentAccount.AccountId);

    }
}
