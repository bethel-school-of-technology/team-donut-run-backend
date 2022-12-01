using rexfinder_api.Models;
using Microsoft.EntityFrameworkCore;

namespace rexfinder_api.Migrations;

public class MyPlacesDbContext : DbContext
{
    public DbSet<MyPlace> MyPlaces { get; set; }
    public DbSet<UserV1> Users { get; set; }
    public DbSet<DonutShop> DonutShop { get; set; }
    public MyPlacesDbContext(DbContextOptions<MyPlacesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MyPlace>(entity =>
        {
            entity.HasKey(p => p.MyPlaceId);
            entity.Property(p => p.Visited);
            entity.HasOne(p => p.User)
            .WithMany(u => u.MyPlaces)
            .HasForeignKey(p => p.UserId).IsRequired();
            entity.Property(p => p.CreatedOn).IsRequired();
            entity.Property(p => p.GooglePlaceId).IsRequired();

        });

        modelBuilder.Entity<UserV1>(entity =>
       {
           entity.HasKey(u => u.UserId);
           entity.Property(u => u.Username).IsRequired();
           entity.HasIndex(x => x.Username).IsUnique();
           entity.Property(u => u.Email).IsRequired();
           entity.HasIndex(u => u.Email).IsUnique();
           entity.Property(u => u.Password).IsRequired();
           entity.Property(u => u.FirstName);
           entity.Property(u => u.LastName);
           entity.Property(u => u.Location);

       });

       modelBuilder.Entity<DonutShop>(entity =>  
       {
        entity.HasKey(d => d.DonutShopId);
        entity.Property(d => d.DonutShopName).IsRequired();
        entity.Property(d => d.DonutShopAddress);
        entity.Property(d => d.DonutShopWebsite);
        entity.Property(d => d.DonutShopCityState);
        entity.HasData(
            new { DonutShopId = 1, DonutShopName = "Five Daughters Bakery", DonutShopAddress = "1900 Eastland Ave Suite 101", DonutShopWebsite = "https://fivedaughtersbakery.com/", DonutShopCityState = "Nashville TN"},
            new { DonutShopId = 2, DonutShopName = "Heavenly Donuts", DonutShopAddress = "1313 Shasta St", DonutShopWebsite = "https://www.heavenlydonut.com/", DonutShopCityState = "Redding CA"},
            new { DonutShopId = 3, DonutShopName = "Top Pot Doughnuts", DonutShopAddress = "6855 35th Ave NE ", DonutShopWebsite = "https://www.toppotdoughnuts.com/", DonutShopCityState = "Seattle WA"},
            new { DonutShopId = 4, DonutShopName = "Kanes Donuts", DonutShopAddress = "1575 Broadway ", DonutShopWebsite = "https://www.kanesdonuts.com/", DonutShopCityState = "Saugus MA"},
            new { DonutShopId = 5, DonutShopName = "Maple Donuts", DonutShopAddress = "3455 East Market St ", DonutShopWebsite = "https://www.mapledonuts.com/", DonutShopCityState = "York PA"},
            new { DonutShopId = 6, DonutShopName = "Donut Country", DonutShopAddress = "1311 Memorial Blvd ", DonutShopWebsite = "https://www.donutcountry.com/", DonutShopCityState = "Murfreesboro TN"},
            new { DonutShopId = 7, DonutShopName = "Voodoo Doughnuts", DonutShopAddress = "98 South Broadway Avenue ", DonutShopWebsite = "https://www.voodoodoughnut.com/", DonutShopCityState = "Denver CO"},
            new { DonutShopId = 8, DonutShopName = "BoSa Donuts", DonutShopAddress = "10876 N 32nd St ", DonutShopWebsite = "https://bosadonutsaz.com/", DonutShopCityState = "Pheonix AZ"},
            new { DonutShopId = 9, DonutShopName = "Buckeye Donuts", DonutShopAddress = "1998 N High ", DonutShopWebsite = "https://buckeyedonuts.net/", DonutShopCityState = "Columbus OH"},
            new { DonutShopId = 10, DonutShopName = "Duck Donuts", DonutShopAddress = "1710 Kenilworth Ave Suite 220 ", DonutShopWebsite = "https://www.duckdonuts.com/charlotte/", DonutShopCityState = "Charlotte NC"},
            new { DonutShopId = 11, DonutShopName = "Sidecar Doughnuts", DonutShopAddress = "175 S Fairfax Ave Unit D ", DonutShopWebsite = "https://sidecardoughnuts.com/", DonutShopCityState = "Los Angeles CA"},
            new { DonutShopId = 12, DonutShopName = "Peter Pan Donut & Pastry Shop", DonutShopAddress = "727 Manhattan Ave ", DonutShopWebsite = "https://www.peterpandonuts.com/", DonutShopCityState = "Brooklyn NY"}
        );
       });
    }
}