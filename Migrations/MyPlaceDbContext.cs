using rexfinder_api.Models;
using Microsoft.EntityFrameworkCore;

namespace rexfinder_api.Migrations;

public class MyPlaceDbContext : DbContext
{
    public DbSet<MyPlace> MyPlaces { get; set; }
    public MyPlaceDbContext(DbContextOptions<MyPlaceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MyPlace>(entity =>
        {
            entity.HasKey(e => e.MyPlaceId);
            entity.Property(e => e.Visited);
            entity.Property(e => e.UserId);
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.GooglePlaceId).IsRequired();

        });
    }
}