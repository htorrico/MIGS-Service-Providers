using Common;
using Common.AspNetCore;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Infraestructure.Context
{
    public class ClientDbContext : DbContext
    //public class ClientDbContext : IdentityDbContext
    //public class ClientDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin,
    //    RoleClaim, UserToken>
    //public class ClientDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
    //       UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>,
    //       IdentityUserToken<string>>
    {

        private IConfigurationLib config;

        public ClientDbContext() : base() { }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        //public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        //public override DbSet<User> Users { get; set; }
        //public override DbSet<Role> Roles { get; set; }
        //public override DbSet<RoleClaim> RoleClaims { get; set; }
        //public override DbSet<UserClaim> UserClaims { get; set; }
        //public override DbSet<UserLogin> UserLogins { get; set; }
        //public override DbSet<UserRole> UserRoles { get; set; }
        //public override DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);           

            IConfigurationRoot configuration = ConfigManager.GetConfig();
            config = new ConfigurationLib(configuration);
            var connectionString = configuration.GetConnectionString("myconn");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(120);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //    .HasIndex(u => u.UserName)
            //    .IsUnique();
            //builder.Entity<User>()
            //    .HasIndex(u => u.Id)
            //    .ValueGeneratedOnAdd();
            //builder.Entity<UserRole>()
            //    .HasNoKey();
            //builder.Entity<UserToken>()
            //    .HasNoKey();


            builder.Entity<UserLogin>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey });
            builder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<UserToken>()
                .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });


            base.OnModelCreating(builder);
            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }

            builder.Entity<User>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.UserClaims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.UserLogins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.UserTokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            //builder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });

            //builder.Entity<IdentityUserClaim<string>>(b =>
            //{
            //    b.Property(e => e.ClaimType).HasColumnName("CType");
            //    b.Property(e => e.ClaimValue).HasColumnName("CValue");
            //});

            //builder.Entity<IdentityUserRole<string>>(b =>
            //{
            //    b.Property(e => e.RoleId).HasColumnName("RoleId");
            //});

            //builder.Entity<IdentityUser>(b =>
            //{
            //    b.ToTable("Users");
            //});

            //builder.Entity<IdentityUserClaim<string>>(b =>
            //{
            //    b.ToTable("UserClaims");
            //});

            //builder.Entity<IdentityUserLogin<string>>(b =>
            //{
            //    b.ToTable("UserLogins");
            //});

            //builder.Entity<IdentityUserToken<string>>(b =>
            //{
            //    b.ToTable("UserTokens");
            //});

            //builder.Entity<IdentityRole>(b =>
            //{
            //    b.ToTable("Roles");
            //});

            //builder.Entity<IdentityRoleClaim<string>>(b =>
            //{
            //    b.ToTable("RoleClaims");
            //});

            //builder.Entity<IdentityUserRole<string>>(b =>
            //{
            //    b.ToTable("UserRoles");
            //});
        }
    }
}
