using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Filmstudion.api.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Filmstudio> Filmstudios {get; set;}
        public DbSet<User> Users { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) => this.Database.EnsureCreated();


        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Filmstudio>().HasData(new Filmstudio
        {
            FilmStudioId = 1,
            FilmStudioName = "Testis",
            FilmStudioCity = "Göteborg",
            Password = "Hej",
            Username = "Olle",
        });
        builder.Entity<User>().HasData(new User
        {
            UserId = 1,
            IsAdmin = true,
            Username = "Göttwald",
            Role = "Admin",
            Password = "hejhej",
        });
    }
    }
}