using Microsoft.EntityFrameworkCore;
using MovieWatcher.Core.Entities;

namespace MovieWatcher.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MediaItem> MediaItems => Set<MediaItem>();
    public DbSet<SeasonItem> Seasons => Set<SeasonItem>();
    public DbSet<EpisodeItem> Episodes => Set<EpisodeItem>();
    public DbSet<PlatformItem> Platforms => Set<PlatformItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TPH setup
        modelBuilder.Entity<MediaItem>()
            .HasDiscriminator<string>("ItemType")
            .HasValue<MovieItem>("Movie")
            .HasValue<SeriesItem>("Series");

        // Cascading deletes
        modelBuilder.Entity<SeasonItem>()
            .HasOne(s => s.Series)
            .WithMany(series => series.Seasons)
            .HasForeignKey(s => s.SeriesItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EpisodeItem>()
            .HasOne(e => e.Season)
            .WithMany(s => s.Episodes)
            .HasForeignKey(e => e.SeasonItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}