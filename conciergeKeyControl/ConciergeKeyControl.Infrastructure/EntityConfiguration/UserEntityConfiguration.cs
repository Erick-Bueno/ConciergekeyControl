using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.HasKey(u => u.id);
        builder.HasIndex(u => u.externalId);
        builder.Property(u => u.name).IsRequired().HasMaxLength(200);
        builder.Property(u => u.email).IsRequired().HasMaxLength(200);
        builder.Property(u => u.password).IsRequired().HasMaxLength(400);
        builder.Property(u => u.iv).IsRequired().HasMaxLength(300);

    }
}