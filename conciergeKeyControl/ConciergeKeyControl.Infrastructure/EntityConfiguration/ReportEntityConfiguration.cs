using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>{
    public void Configure(EntityTypeBuilder<Report> builder){
       builder.HasKey(r => r.Id);
       builder.HasIndex(r => r.ExternalId);
       builder.Property(r => r.Status).IsRequired();
       builder.Property(r => r.WithdrawalDate).IsRequired();
       builder.HasOne(r => r.User)
       .WithMany(u => u.Reports)
       .HasForeignKey(r => r.IdUser);
       builder.HasOne(r => r.Key)
       .WithMany(k => k.reports)
       .HasForeignKey(r => r.IdKey);
    }
}
