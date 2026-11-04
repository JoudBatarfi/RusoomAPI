using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rusoom.Entities.Identity;
using Rusoom.Entities.Children;
using Rusoom.Controllers;

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

            // Child
            modelBuilder.Entity<Child>().ToTable(
                "Child",
                "children",
                table => table.HasCheckConstraint(
                    "CK_Child_BirthMonth",
                    "[BirthMonth] BETWEEN 1 AND 12"
                    )
                );

            // ChildAccess
            modelBuilder.Entity<ChildAccess>().ToTable(
                "ChildAccess", 
                "children",
                table => {
                    table.HasCheckConstraint(
                        "CK_ChildAccess_Role",
                        "[Role] IN (N'Owner', N'Collaborator')");


                    table.HasCheckConstraint(
                        "CK_ChildAccess_CollaboratorDisplayLabel",
                        "[Role] = N'Owner' OR [DisplayLabel] IS NOT NULL");
                }
                );
                

            // ChildAccess
            modelBuilder.Entity<ChildAccess>()
                .HasOne<Child>()
                .WithMany()
                .HasForeignKey(childAccess => childAccess.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChildAccess>()
                .HasOne<Parent>()
                .WithMany()
                .HasForeignKey(childAccess => childAccess.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChildAccess>()
                .HasIndex(childAccess => new {childAccess.ParentId, childAccess.ChildId})
                .IsUnique();

            modelBuilder.Entity<ChildAccess>()
                .Property(childAccess => childAccess.Role)
                .HasConversion<string>()
                .HasMaxLength(12);

            modelBuilder.Entity<ChildAccess>()
                .HasIndex(childAccess => childAccess.ChildId)
                .IsUnique()
                .HasFilter("[Role] = N'Owner'");

            modelBuilder.Entity<ChildAccess>()
                .Property(childAccess => childAccess.DisplayLabel)
                .HasMaxLength(50);


            // Child
            modelBuilder.Entity<Child>()
                .HasOne<Parent>()
                .WithMany()
                .HasForeignKey(child => child.DeletedBy)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Child>()
                .Property(child => child.DisplayName)
                .HasMaxLength(50);

            // Parent
            modelBuilder.Entity<Parent>()
                .HasIndex(parent => parent.NormalizedEmail)
                .IsUnique();

            modelBuilder.Entity<Parent>()
                .Property(parent => parent.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Parent>()
                .Property(parent => parent.CountryCode)
                .HasMaxLength(2);

            modelBuilder.Entity<Parent>()
                .Property(parent => parent.Timezone)
                .HasMaxLength(100);

            modelBuilder.Entity<Parent>()
                .Property(parent => parent.Locale)
                .HasMaxLength(64);

            // PrivacyPolicy
            modelBuilder.Entity<PrivacyPolicy>()
                .HasIndex(privacyPolicy => privacyPolicy.Version)
                .IsUnique();

            modelBuilder.Entity<PrivacyPolicy>()
                .HasIndex(privacyPolicy => privacyPolicy.IsCurrent)
                .IsUnique()
                .HasFilter("[IsCurrent] = 1");

            modelBuilder.Entity<PrivacyPolicy>()
                .Property(privacyPolicy => privacyPolicy.UrlEN)
                .HasMaxLength(2048);

            modelBuilder.Entity<PrivacyPolicy>()
                .Property(privacyPolicy => privacyPolicy.UrlAR)
                .HasMaxLength(2048);

            modelBuilder.Entity<PrivacyPolicy>()
                .Property(privacyPolicy => privacyPolicy.ContentHash)
                .HasMaxLength(64);

            
        }
    }



   
}