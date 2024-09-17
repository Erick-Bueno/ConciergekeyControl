using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TokenEntityConfiguration : IEntityTypeConfiguration<Token>{
    public void Configure(EntityTypeBuilder<Token> builder){
        builder.HasKey(t => t.id);
        builder.HasIndex(t => t.externalId);
        builder.Property(t => t.email).IsRequired().HasMaxLength(200);
        builder.Property(t => t.refreshToken).IsRequired().HasMaxLength(300);
    }
}