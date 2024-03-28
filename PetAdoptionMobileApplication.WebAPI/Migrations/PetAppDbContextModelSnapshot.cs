﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoptionMobileApplication.WebAPI.Data;

#nullable disable

namespace PetAdoptionMobileApplication.WebAPI.Migrations
{
    [DbContext(typeof(PetAppDbContext))]
    partial class PetAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdoptionStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pets", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed273b65-b091-49f1-8b05-35ae7313e0af"),
                            AdoptionStatus = 1,
                            BirthDate = new DateTime(2015, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Dog - Alaskan Klee Kai",
                            Description = "loyal, intelligent, vigilant",
                            Gender = 0,
                            Image = "alaskan_klee_kai.jpg",
                            IsActive = true,
                            PetName = "Bushu",
                            Price = 250.0,
                            View = 0
                        },
                        new
                        {
                            Id = new Guid("e03dbb3e-09d1-4add-9e4e-32f501e7a1a5"),
                            AdoptionStatus = 1,
                            BirthDate = new DateTime(2007, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Cat - Siamese",
                            Description = "judgemental, loving, intelligent, fighter",
                            Gender = 1,
                            Image = "ioana.png",
                            IsActive = true,
                            PetName = "Ioana",
                            Price = 5000.0,
                            View = 0
                        },
                        new
                        {
                            Id = new Guid("28d3482d-f301-40e7-b855-a8a0006c5eb3"),
                            AdoptionStatus = 1,
                            BirthDate = new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Dog - Belgian Malinois",
                            Description = "confident, smart, hardworking",
                            Gender = 0,
                            Image = "jack.jpg",
                            IsActive = true,
                            PetName = "Jack",
                            Price = 500.0,
                            View = 0
                        },
                        new
                        {
                            Id = new Guid("1fdca0bb-1329-423f-b0eb-606100ed303a"),
                            AdoptionStatus = 1,
                            BirthDate = new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Breed = "Cat - Snowshoe",
                            Description = "Loving, curious, family-oriented, vocal",
                            Gender = 1,
                            Image = "pearl.jpg",
                            IsActive = true,
                            PetName = "Pearl",
                            Price = 500.0,
                            View = 0
                        });
                });

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.UserAdoptions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AdoptedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Adoptions", (string)null);
                });

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.UserFavs", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<Guid>("PetId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "PetId");

                    b.HasIndex("PetId1");

                    b.HasIndex("UserId1");

                    b.ToTable("Favs", (string)null);
                });

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.UserAdoptions", b =>
                {
                    b.HasOne("PetAdoptionMobileApplication.WebAPI.Data.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoptionMobileApplication.WebAPI.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetAdoptionMobileApplication.WebAPI.Data.Entities.UserFavs", b =>
                {
                    b.HasOne("PetAdoptionMobileApplication.WebAPI.Data.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoptionMobileApplication.WebAPI.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
