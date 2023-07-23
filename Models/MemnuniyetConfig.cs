using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace anketdeneme.Models
{
    public class MemnuniyetConfig : IEntityTypeConfiguration<Memnuniyet>
    {
        public void Configure(EntityTypeBuilder<Memnuniyet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
             new Memnuniyet { Id = 1, MemnuniyetDerecesi = "Çok Memnunum" },
             new Memnuniyet { Id = 2, MemnuniyetDerecesi = "Memnunum" },
             new Memnuniyet { Id = 3, MemnuniyetDerecesi = "Nötrüm" },
             new Memnuniyet { Id = 4, MemnuniyetDerecesi = "Memnun Değilim" },
             new Memnuniyet { Id = 5, MemnuniyetDerecesi = "Hiç Memnun Değilim" },
             new Memnuniyet { Id = 6, MemnuniyetDerecesi = "Memnun Değilim" }
            );

        }
    }

}