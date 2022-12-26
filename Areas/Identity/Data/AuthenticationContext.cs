using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using practiceAuthentication.Areas.Identity.Data;

namespace practiceAuthentication.Data;

public class AuthenticationContext : IdentityDbContext<AuthenticationUser>
{
    public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuthenticationUserEntityConfiguration());
    }



}
public class AuthenticationUserEntityConfiguration : IEntityTypeConfiguration<AuthenticationUser>
{
    public void Configure(EntityTypeBuilder<AuthenticationUser> builder)
    {
        builder.Property(u => u.Firstname).HasMaxLength(255);
        builder.Property(u => u.Lastname).HasMaxLength(255);
    }
}
