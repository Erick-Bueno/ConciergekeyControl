using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class KeyEntityConfiguration : IEntityTypeConfiguration<Key>{
    public void Configure(EntityTypeBuilder<Key> builder){
        builder.HasKey(k => k.id);
        builder.HasIndex(k => k.externalId);
        builder.HasOne(k => k.room)
        .WithMany(r => r.keys)
        .HasForeignKey(k => k.idRoom);
    }
}