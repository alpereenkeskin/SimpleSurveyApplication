using Microsoft.EntityFrameworkCore;

namespace anketdeneme.Models
{
    public class RepoDbContext : DbContext
    {
        public RepoDbContext(DbContextOptions<RepoDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemnuniyetConfig());
            modelBuilder.ApplyConfiguration(new SorularConfig());
            modelBuilder.ApplyConfiguration(new UsersConfig());
        }
        public DbSet<Memnuniyet>? Memnuniyets { get; set; }
        public DbSet<Sorular>? Sorulars { get; set; }
        public DbSet<Users>? Users { get; set; }
        public DbSet<AppRole>? AppRoles { get; set; }

    }

}