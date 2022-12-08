﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rexfinder_api.Migrations;

#nullable disable

namespace rexfinderapi.Migrations
{
    [DbContext(typeof(MyPlacesDbContext))]
    partial class MyPlacesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("DonutShopCityState")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonutShopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DonutShopPhotoURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonutShopWebsite")
                        .HasColumnType("TEXT");

                    b.HasKey("DonutShopId");

                    b.ToTable("DonutShop");

                    b.HasData(
                        new
                        {
                            DonutShopId = 1,
                            DonutShopAddress = "1900 Eastland Ave Suite 101",
                            DonutShopCityState = "Nashville TN",
                            DonutShopName = "Five Daughters Bakery",
                            DonutShopPhotoURL = "https://cdn.shopify.com/s/files/1/0015/8338/2600/files/FDB_Mar2_AmberUlmer-030_480x480.JPG?v=1535141819",
                            DonutShopWebsite = "https://fivedaughtersbakery.com/"
                        },
                        new
                        {
                            DonutShopId = 2,
                            DonutShopAddress = "1313 Shasta St",
                            DonutShopCityState = "Redding CA",
                            DonutShopName = "Heavenly Donuts",
                            DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5ae2002d9d5abb364c849f56/1525803588583-DVZJCKEO4ZAXUKN1S2FC/store-shasta-st-redding-ca-heavenly-donuts.jpg?format=1000w",
                            DonutShopWebsite = "https://www.heavenlydonut.com/"
                        },
                        new
                        {
                            DonutShopId = 3,
                            DonutShopAddress = "6855 35th Ave NE ",
                            DonutShopCityState = "Seattle WA",
                            DonutShopName = "Top Pot Doughnuts",
                            DonutShopPhotoURL = "https://cdn.shopify.com/s/files/1/1349/1039/files/featured-covid_858x_9254b94f-b880-4faa-820f-ce14e9bee403_1716x.jpg?v=1613784268",
                            DonutShopWebsite = "https://www.toppotdoughnuts.com/"
                        },
                        new
                        {
                            DonutShopId = 4,
                            DonutShopAddress = "1575 Broadway ",
                            DonutShopCityState = "Saugus MA",
                            DonutShopName = "Kanes Donuts",
                            DonutShopPhotoURL = "https://www.kanesdonuts.com/site/img/locations/kanes-legacy.jpg",
                            DonutShopWebsite = "https://www.kanesdonuts.com/"
                        },
                        new
                        {
                            DonutShopId = 5,
                            DonutShopAddress = "3455 East Market St ",
                            DonutShopCityState = "York PA",
                            DonutShopName = "Maple Donuts",
                            DonutShopPhotoURL = "https://www.mapledonuts.com/uploads/4532913028_b1c7972559_z.jpg",
                            DonutShopWebsite = "https://www.mapledonuts.com/"
                        },
                        new
                        {
                            DonutShopId = 6,
                            DonutShopAddress = "1311 Memorial Blvd ",
                            DonutShopCityState = "Murfreesboro TN",
                            DonutShopName = "Donut Country",
                            DonutShopPhotoURL = "https://cdn.websites.hibu.com/5b9a48150fc94472bd49727cc22ee066/dms3rep/multi/Gallery-11.jpg",
                            DonutShopWebsite = "https://www.donutcountry.com/"
                        },
                        new
                        {
                            DonutShopId = 7,
                            DonutShopAddress = "98 South Broadway Avenue ",
                            DonutShopCityState = "Denver CO",
                            DonutShopName = "Voodoo Doughnuts",
                            DonutShopPhotoURL = "https://www.voodoodoughnut.com/wp-content/uploads/2022/11/Broadway_B.jpg",
                            DonutShopWebsite = "https://www.voodoodoughnut.com/"
                        },
                        new
                        {
                            DonutShopId = 8,
                            DonutShopAddress = "10876 N 32nd St ",
                            DonutShopCityState = "Pheonix AZ",
                            DonutShopName = "BoSa Donuts",
                            DonutShopPhotoURL = "https://bosadonutsaz.com/wp-content/uploads/2019/05/Logo-1.png",
                            DonutShopWebsite = "https://bosadonutsaz.com/"
                        },
                        new
                        {
                            DonutShopId = 9,
                            DonutShopAddress = "1998 N High ",
                            DonutShopCityState = "Columbus OH",
                            DonutShopName = "Buckeye Donuts",
                            DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5b328a679f8770158d2015fd/19b6a6af-8d28-4860-b610-f0ea80dd2c29/NEW+WEBSITE+HEADER+IMAGE_JPG.jpg?format=2500w",
                            DonutShopWebsite = "https://buckeyedonuts.net/"
                        },
                        new
                        {
                            DonutShopId = 10,
                            DonutShopAddress = "1710 Kenilworth Ave Suite 220 ",
                            DonutShopCityState = "Charlotte NC",
                            DonutShopName = "Duck Donuts",
                            DonutShopPhotoURL = "https://d2nmqj11l1ij0u.cloudfront.net//images/holiday%202022/website-holiday1.jpg",
                            DonutShopWebsite = "https://www.duckdonuts.com/charlotte/"
                        },
                        new
                        {
                            DonutShopId = 11,
                            DonutShopAddress = "175 S Fairfax Ave Unit D ",
                            DonutShopCityState = "Los Angeles CA",
                            DonutShopName = "Sidecar Doughnuts",
                            DonutShopPhotoURL = "https://sidecarmigrate.wpenginepowered.com/wp-content/uploads/2020/08/Hero-4.jpg",
                            DonutShopWebsite = "https://sidecardoughnuts.com/"
                        },
                        new
                        {
                            DonutShopId = 12,
                            DonutShopAddress = "727 Manhattan Ave ",
                            DonutShopCityState = "Brooklyn NY",
                            DonutShopName = "Peter Pan Donut & Pastry Shop",
                            DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5fb40e02d2777464bb473010/1609262636242-NAMDR65IQFCYCMX8QBOG/peter_pan_bakery_greenpoint_brooklyn_ext.jpg?format=1500w",
                            DonutShopWebsite = "https://www.peterpandonuts.com/"
                        });
                });

            modelBuilder.Entity("rexfinder_api.Models.Experiences", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExperienceNotes")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExperienceTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExperienceUserLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstGooglePlaceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondGooglePlaceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThirdGooglePlaceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExperienceId");

                    b.HasIndex("UserId");

                    b.ToTable("Experiences");
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

            modelBuilder.Entity("rexfinder_api.Models.Experiences", b =>
                {
                    b.HasOne("rexfinder_api.Models.UserV1", "User")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                    b.Navigation("Experiences");

                    b.Navigation("MyPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
