using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class MovementConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> entity)
    {
        entity.HasKey(e => e.Id).HasName("Movement_pkey");                      //int
        entity.Property(Movement => Movement.Amount);                           //decimal

        entity.Property(Movement => Movement.Destination).HasMaxLength(100).IsRequired();


        entity.Property(Movement => Movement.TransferredDateTime);

        entity.Property(Movement => Movement.TransferStatus);




        entity
            .HasOne(Movement => Movement.Account)
            .WithMany(Movement => Movement.Movements)
            .HasForeignKey(Movement => Movement.Id);

    }
}
