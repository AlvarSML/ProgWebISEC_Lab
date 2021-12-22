using ASP6_SinAuth.Areas.Identity.Data;
using ASP6_SinAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP6_SinAuth.Data;

public class ctxDatos : IdentityDbContext<User>
{
    public ctxDatos(DbContextOptions<ctxDatos> options)
        : base(options)
    {
    }

    public DbSet<Test> Test { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<TestType> TestType { get; set; }
    public DbSet<Laboratory> Laboratory { get; set; }
    public DbSet<LaboratoryWorker> LaboratoryWorkers { get; set; }
    public DbSet<Client> Client { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

 
}
