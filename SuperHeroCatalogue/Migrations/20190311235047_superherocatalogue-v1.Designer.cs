﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperHeroCatalogue;

namespace SuperHeroCatalogue.Migrations
{
    [DbContext(typeof(SuperHeroCatalogueDb))]
    [Migration("20190311235047_superherocatalogue-v1")]
    partial class superherocataloguev1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperHeroCatalogue.Models.AuditEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Entity");

                    b.Property<int>("EntityId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("AuditEvents");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.ProtectionArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Lat");

                    b.Property<float>("Long");

                    b.Property<string>("Name");

                    b.Property<float>("Radius");

                    b.HasKey("Id");

                    b.ToTable("ProtectionAreas");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias");

                    b.Property<string>("Name");

                    b.Property<int?>("ProtectionAreaId");

                    b.HasKey("Id");

                    b.HasIndex("ProtectionAreaId");

                    b.ToTable("SuperHeroes");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.SuperPower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SuperPowers");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.SuperPowerHero", b =>
                {
                    b.Property<int>("SuperHeroId");

                    b.Property<int>("SuperPowerId");

                    b.HasKey("SuperHeroId", "SuperPowerId");

                    b.HasIndex("SuperPowerId");

                    b.ToTable("SuperPowerHeroes");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.SuperHero", b =>
                {
                    b.HasOne("SuperHeroCatalogue.Models.ProtectionArea", "ProtectionArea")
                        .WithMany()
                        .HasForeignKey("ProtectionAreaId");
                });

            modelBuilder.Entity("SuperHeroCatalogue.Models.SuperPowerHero", b =>
                {
                    b.HasOne("SuperHeroCatalogue.Models.SuperHero", "SuperHero")
                        .WithMany("SuperPowerHeroes")
                        .HasForeignKey("SuperHeroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SuperHeroCatalogue.Models.SuperPower", "SuperPower")
                        .WithMany("SuperPowerHeroes")
                        .HasForeignKey("SuperPowerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
