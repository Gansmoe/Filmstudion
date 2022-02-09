﻿// <auto-generated />
using Filmstudion.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Filmstudion.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220208183944_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Filmstudion.api.Models.Filmstudio", b =>
                {
                    b.Property<int>("FilmStudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FilmStudioCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilmStudioName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("FilmStudioId");

                    b.ToTable("Filmstudios");

                    b.HasData(
                        new
                        {
                            FilmStudioId = 1,
                            FilmStudioCity = "Göteborg",
                            FilmStudioName = "Testis",
                            Password = "Hej",
                            Username = "Olle"
                        });
                });

            modelBuilder.Entity("Filmstudion.api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsAdmin = true,
                            Password = "hejhej",
                            Role = "Admin",
                            Username = "Göttwald"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
