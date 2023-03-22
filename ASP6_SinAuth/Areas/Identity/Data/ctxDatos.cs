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
    
    public DbSet<LaboratoryManager> LaboratoryManager { get; set; }
    public DbSet<Test> Test { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<TestType> TestType { get; set; }    
    public DbSet<Client>? Client { get; set; }
    public DbSet<Laboratory> Laboratory { get; set; }

    public DbSet<LaboratoryWorker> LaboratoryWorker { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

        base.OnModelCreating(builder);
        User usr1 = new User()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            Name = "Administrador",
            Email = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            LockoutEnabled = true,
            PhoneNumber = "1234567890",
            EmailConfirmed = true
        };

        string hash = passwordHasher.HashPassword(usr1, "asd1234");
        usr1.PasswordHash = hash;
        builder.Entity<User>().HasData(usr1);

        User usr2 = new User()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e6",
            UserName = "Client",
            Name = "Cliente",
            Email = "client@admin.com",
            NormalizedUserName = "CLIENT@ADMIN.COM",
            LockoutEnabled = true,
            PhoneNumber = "1234567890",
            EmailConfirmed = true
        };        

        hash = passwordHasher.HashPassword(usr2, "asd1234");
        usr2.PasswordHash = hash;
        builder.Entity<User>().HasData(usr2);


        LaboratoryManager lm = new LaboratoryManager()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e7",
            UserName = "Manager",
            Name = "Manager",
            Email = "manager@manager.com",
            NormalizedUserName="MANAGER@MANAGER.COM",
            LockoutEnabled = false,
            PhoneNumber = "1234567890",
            FirstName = "Man",
            LastName = "Ager",
            NationalID = "1234567890",
            CompanyAddress = "gg"
        };

        hash = passwordHasher.HashPassword(lm, "asd1234");
        builder.Entity<LaboratoryManager>().HasData(lm);
        lm.PasswordHash = hash;
        //builder.Entity<Laboratory>().HasData(l1);

        builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "LaboratoryWorker", ConcurrencyStamp = "2", NormalizedName = "Laboratory Worker" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7331", Name = "LaboratoryManager", ConcurrencyStamp = "3", NormalizedName = "Laboratory Manager" }
                );

    }


}
