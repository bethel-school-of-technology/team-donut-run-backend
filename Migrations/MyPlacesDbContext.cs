using rexfinder_api.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace rexfinder_api.Migrations;

public class MyPlacesDbContext : DbContext
{
    public DbSet<MyPlace> MyPlaces { get; set; }
    public DbSet<User> Users { get; set; }
    public MyPlacesDbContext(DbContextOptions<MyPlacesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MyPlace>(entity =>
        {
            entity.HasKey(e => e.MyPlaceId);
            entity.Property(e => e.Visited);
            entity.Property(e => e.CreatedOn);
            entity.Property(e => e.GooglePlaceId);
            entity.HasOne(e => e.User)
            .WithMany(e => e.MyPlaces)
            .HasForeignKey(e => e.UserId).IsRequired();

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.LastName);
            entity.Property(e => e.Username);
            entity.Property(e => e.PasswordHash);
            entity.Property(e => e.Location);
            entity.Property(e => e.Email);
        });
    }
}