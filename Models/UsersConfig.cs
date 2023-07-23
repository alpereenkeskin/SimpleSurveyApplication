using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace anketdeneme.Models
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
        }
    }

}