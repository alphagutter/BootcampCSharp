
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;


///<remarks>
///Configuration for the Extraction class
///</remarks>
public class ExtractionConfiguration : IEntityTypeConfiguration<Extraction>
{
    public void Configure(EntityTypeBuilder<Extraction> entity)
    {
        //primary key
        entity
            .HasKey(e => e.Id)
            .HasName("Extraction_pkey");


        //foreign key with account
        entity
            .HasOne(d => d.Account)
            .WithMany(a => a.Extractions)
            .HasForeignKey(d => d.AccountId)
            .IsRequired();

        //foreign key with Bank
        entity
            .HasOne(deposit => deposit.Bank)
            .WithMany(bank => bank.Extractions)
            .HasForeignKey(deposit => deposit.BankId)
            .IsRequired();

    }
}
