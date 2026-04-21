namespace MovieWatcher.Core.Entities;

/// <summary>
/// Specialized item for series, containing seasons.
/// </summary>
public class SeriesItem : MediaItem
{
    public List<SeasonItem> Seasons { get; set; } = new();
}