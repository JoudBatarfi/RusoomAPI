using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rusoom.Entities.Identity;
using Rusoom.Entities.Children;

namespace Rusoom.Infrastructure.Data
{
    public class RusoomDbContext : IdentityUserContext<Parent, Guid>
    {
        public RusoomDbContext(DbContextOptions<RusoomDbContext> options)
        : base(options)
        { }

        public DbSet<Child> Children => Set<Child>();
        public DbSet<ChildAccess> ChildAccesses => Set<ChildAccess>();
        public DbSet<PrivacyPolicy> PrivacyPolicies => Set<PrivacyPolicy>();
        public DbSet<ParentPolicyAcceptance> ParentPolicyAcceptances => Set<ParentPolicyAcceptance>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();



        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("identity");

            modelBuilder.Entity<Child>().ToTable("Child", "children");
            modelBuilder.Entity<ChildAccess>().ToTable("ChildAccess", "children");
        }
    }



   
}