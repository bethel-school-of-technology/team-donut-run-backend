﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rexfinder_api.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    [DbContext(typeof(MyPlacesDbContext))]
    [Migration("20221125202217_FixingDonutShop")]
    partial class FixingDonutShop
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("rexfinder_api.Models.DonutShop", b =>
                {
                    b.Property<int>("DonutShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DonutShopAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonutShopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DonutShopWebsite")
                        .HasColumnType("TEXT");

                    b.HasKey("DonutShopId");

                    b.ToTable("DonutShop");
                });

            modelBuilder.Entity("rexfinder_api.Models.MyPlace", b =>
                {
                    b.Property<int>("MyPlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedOn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GooglePlaceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Visited")
                        .HasColumnType("INTEGER");

                    b.HasKey("MyPlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("MyPlaces");
                });

            modelBuilder.Entity("rexfinder_api.Models.UserV1", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rexfinder_api.Models.MyPlace", b =>
                {
                    b.HasOne("rexfinder_api.Models.UserV1", "User")
                        .WithMany("MyPlaces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("rexfinder_api.Models.UserV1", b =>
                {
                    b.Navigation("MyPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
