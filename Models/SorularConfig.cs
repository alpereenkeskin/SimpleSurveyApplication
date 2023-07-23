using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace anketdeneme.Models
{
    public class SorularConfig : IEntityTypeConfiguration<Sorular>
    {
        public void Configure(EntityTypeBuilder<Sorular> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).HasMaxLength(300);
            builder.Property(x => x.Soyad).HasMaxLength(300);
            builder.Property(x => x.MesajKutusu).HasMaxLength(int.MaxValue);
        }
    }

}