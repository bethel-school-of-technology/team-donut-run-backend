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
        entity.Property(d => d.DonutShopPhotoURL);
        entity.HasData(
            new { DonutShopId = 1, DonutShopName = "Five Daughters Bakery", DonutShopAddress = "1900 Eastland Ave Suite 101", DonutShopWebsite = "https://fivedaughtersbakery.com/", DonutShopCityState = "Nashville TN", DonutShopPhotoURL = "https://cdn.shopify.com/s/files/1/0015/8338/2600/files/FDB_Mar2_AmberUlmer-030_480x480.JPG?v=1535141819"},
            new { DonutShopId = 2, DonutShopName = "Heavenly Donuts", DonutShopAddress = "1313 Shasta St", DonutShopWebsite = "https://www.heavenlydonut.com/", DonutShopCityState = "Redding CA", DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5ae2002d9d5abb364c849f56/1525803588583-DVZJCKEO4ZAXUKN1S2FC/store-shasta-st-redding-ca-heavenly-donuts.jpg?format=1000w"},
            new { DonutShopId = 3, DonutShopName = "Top Pot Doughnuts", DonutShopAddress = "6855 35th Ave NE ", DonutShopWebsite = "https://www.toppotdoughnuts.com/", DonutShopCityState = "Seattle WA", DonutShopPhotoURL = "https://cdn.shopify.com/s/files/1/1349/1039/files/featured-covid_858x_9254b94f-b880-4faa-820f-ce14e9bee403_1716x.jpg?v=1613784268"},
            new { DonutShopId = 4, DonutShopName = "Kanes Donuts", DonutShopAddress = "1575 Broadway ", DonutShopWebsite = "https://www.kanesdonuts.com/", DonutShopCityState = "Saugus MA", DonutShopPhotoURL = "https://www.kanesdonuts.com/site/img/locations/kanes-legacy.jpg"},
            new { DonutShopId = 5, DonutShopName = "Maple Donuts", DonutShopAddress = "3455 East Market St ", DonutShopWebsite = "https://www.mapledonuts.com/", DonutShopCityState = "York PA", DonutShopPhotoURL = "https://www.mapledonuts.com/uploads/4532913028_b1c7972559_z.jpg"},
            new { DonutShopId = 6, DonutShopName = "Donut Country", DonutShopAddress = "1311 Memorial Blvd ", DonutShopWebsite = "https://www.donutcountry.com/", DonutShopCityState = "Murfreesboro TN", DonutShopPhotoURL = "https://cdn.websites.hibu.com/5b9a48150fc94472bd49727cc22ee066/dms3rep/multi/Gallery-11.jpg"},
            new { DonutShopId = 7, DonutShopName = "Voodoo Doughnuts", DonutShopAddress = "98 South Broadway Avenue ", DonutShopWebsite = "https://www.voodoodoughnut.com/", DonutShopCityState = "Denver CO", DonutShopPhotoURL = "https://www.voodoodoughnut.com/wp-content/uploads/2022/11/Broadway_B.jpg"},
            new { DonutShopId = 8, DonutShopName = "BoSa Donuts", DonutShopAddress = "10876 N 32nd St ", DonutShopWebsite = "https://bosadonutsaz.com/", DonutShopCityState = "Pheonix AZ", DonutShopPhotoURL = "https://bosadonutsaz.com/wp-content/uploads/2019/05/Logo-1.png"},
            new { DonutShopId = 9, DonutShopName = "Buckeye Donuts", DonutShopAddress = "1998 N High ", DonutShopWebsite = "https://buckeyedonuts.net/", DonutShopCityState = "Columbus OH", DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5b328a679f8770158d2015fd/19b6a6af-8d28-4860-b610-f0ea80dd2c29/NEW+WEBSITE+HEADER+IMAGE_JPG.jpg?format=2500w"},
            new { DonutShopId = 10, DonutShopName = "Duck Donuts", DonutShopAddress = "1710 Kenilworth Ave Suite 220 ", DonutShopWebsite = "https://www.duckdonuts.com/charlotte/", DonutShopCityState = "Charlotte NC", DonutShopPhotoURL = "https://d2nmqj11l1ij0u.cloudfront.net//images/holiday%202022/website-holiday1.jpg"},
            new { DonutShopId = 11, DonutShopName = "Sidecar Doughnuts", DonutShopAddress = "175 S Fairfax Ave Unit D ", DonutShopWebsite = "https://sidecardoughnuts.com/", DonutShopCityState = "Los Angeles CA", DonutShopPhotoURL = "https://sidecarmigrate.wpenginepowered.com/wp-content/uploads/2020/08/Hero-4.jpg"},
            new { DonutShopId = 12, DonutShopName = "Peter Pan Donut & Pastry Shop", DonutShopAddress = "727 Manhattan Ave ", DonutShopWebsite = "https://www.peterpandonuts.com/", DonutShopCityState = "Brooklyn NY", DonutShopPhotoURL = "https://images.squarespace-cdn.com/content/v1/5fb40e02d2777464bb473010/1609262636242-NAMDR65IQFCYCMX8QBOG/peter_pan_bakery_greenpoint_brooklyn_ext.jpg?format=1500w"}
        );
       });
    }
}