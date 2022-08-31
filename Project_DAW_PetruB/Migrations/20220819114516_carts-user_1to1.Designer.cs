﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_DAW_PetruB.Entities;

namespace Project_DAW_PetruB.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220819114516_carts-user_1to1")]
    partial class cartsuser_1to1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project_DAW_PetruB.Entities.Cart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Project_DAW_PetruB.Entities.License", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Project_DAW_PetruB.Entities.Producer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Project_DAW_PetruB.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project_DAW_PetruB.Entities.Cart", b =>
                {
                    b.HasOne("Project_DAW_PetruB.Entities.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Project_DAW_PetruB.Entities.Cart", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_DAW_PetruB.Entities.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
