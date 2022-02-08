using Microsoft.EntityFrameworkCore;

namespace Filmstudion.api.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Filmstudio> Filmstudios {get; set;}


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
    }
    }
}