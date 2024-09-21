using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class KeyEntityConfiguration : IEntityTypeConfiguration<Key>{
    public void Configure(EntityTypeBuilder<Key> builder){
        builder.HasKey(k => k.Id);
        builder.HasIndex(k => k.ExternalId);
        builder.HasOne(k => k.Room)
        .WithMany(r => r.Keys)
        .HasForeignKey(k => k.IdRoom);
    }
}