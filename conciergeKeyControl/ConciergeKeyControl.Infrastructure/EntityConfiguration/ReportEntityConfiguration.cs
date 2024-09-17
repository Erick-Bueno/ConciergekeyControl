using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>{
    public void Configure(EntityTypeBuilder<Report> builder){
       builder.HasKey(r => r.id);
       builder.HasIndex(r => r.externalId);
       builder.Property(r => r.status).IsRequired();
       builder.Property(r => r.withdrawalDate).IsRequired();
       builder.HasOne(r => r.user)
       .WithMany(u => u.reports)
       .HasForeignKey(r => r.idUser);
       builder.HasOne(r => r.key)
       .WithMany(k => k.reports)
       .HasForeignKey(r => r.idKey);
    }
}
