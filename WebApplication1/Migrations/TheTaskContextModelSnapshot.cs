﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(TheTaskContext))]
    partial class TheTaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PropertyTest")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("78d2ee38-8cd5-4709-a8db-c697966575ef"),
                            Description = "About clothes for men and women",
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = new Guid("3e4edaca-6e16-4826-b413-5194eaad821c"),
                            Description = "About electronic for different situations",
                            Name = "Electronic"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.TheTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TheTask", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("56f740ff-40fd-47d3-a565-ffc9418544cb"),
                            CategoryId = new Guid("78d2ee38-8cd5-4709-a8db-c697966575ef"),
                            CreatedAt = new DateTime(2024, 11, 1, 23, 44, 37, 80, DateTimeKind.Utc).AddTicks(623),
                            Description = "New vocabulary to study and practicing",
                            Priority = 0,
                            Title = "Search new words to learn in English"
                        },
                        new
                        {
                            Id = new Guid("46d89227-eca6-48c1-a78c-867a064bbd9f"),
                            CategoryId = new Guid("3e4edaca-6e16-4826-b413-5194eaad821c"),
                            CreatedAt = new DateTime(2024, 11, 1, 23, 44, 37, 80, DateTimeKind.Utc).AddTicks(628),
                            Description = "Improving speaking to understand better native speakers",
                            Priority = 2,
                            Title = "Practice English in platforms where you can speak with other people"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.TheTask", b =>
                {
                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("TheTasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Navigation("TheTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
