using rexfinder_api.Models;
using Microsoft.EntityFrameworkCore;

namespace rexfinder_api.Migrations;

public class MyPlacesDbContext : DbContext
{
    public DbSet<MyPlace> MyPlaces { get; set; }
    public DbSet<UserV1> Users { get; set; }
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
    }
}