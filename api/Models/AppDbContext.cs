using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Filmstudion.api.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Filmstudio> Filmstudios {get; set;}
        public DbSet<Film> Films {get; set;}


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) => this.Database.EnsureCreated();


        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Filmstudio>().HasData(new Filmstudio
        {
            Id = 1,
            StudioIdentifier = "1",
            FilmStudioName = "Testis",
            FilmStudioCity = "Göteborg",
            Password = "Hej",
            Username = "Olle",
        });


            builder.Entity<User>().HasData(new User
            {
                Id = "1",
                Email = "hej@hej.se",
                IsAdmin = true,
                FilmStudioId = "1",
                UserName = "Göttwald",
                Role = "Admin",

            });

            builder.Entity<Film>().HasData(new Film
            {
                FilmId = 1,
                FilmCopies = new List<FilmCopy>(),
                Country = "Swe",
                Director = "Kalle",
                Name = "HejHej",
                ReleaseDate = System.DateTime.Now
            });
    }
    }
}