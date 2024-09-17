using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.id);
        builder.HasIndex(r => r.externalId);
        builder.Property(r => r.name).IsRequired().HasMaxLength(200);
        
    }
}