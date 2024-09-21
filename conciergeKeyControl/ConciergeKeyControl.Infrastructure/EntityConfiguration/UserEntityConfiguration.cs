using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.ExternalId);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(200);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(400);
        builder.Property(u => u.Iv).IsRequired().HasMaxLength(300);

    }
}