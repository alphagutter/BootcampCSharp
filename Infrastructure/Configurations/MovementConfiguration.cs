    using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

///<remarks>
///Configuration for the Movement class
///</remarks>
public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> entity)
    {
        entity
            .HasKey(e => e.Id)
            .HasName("Movements_pkey");


        /*for changes made in 'Account' table*/
        entity
            .HasOne(movements => movements.Account)
            .WithMany(account => account.Movements)
            .HasForeignKey(movements => movements.OriginAccountId);
        
        entity
            .HasOne(movements => movements.Account)
            .WithMany(account => account.Movements)
            .HasForeignKey(movements => movements.DestinationAccountId);


    }
}