namespace MovieWatcher.Core.Entities;

/// <summary>
/// Represents a single season of a TV series.
/// </summary>
public class SeasonItem
{
    public Guid Id { get; set; }
    public int SeasonNumber { get; set; }
    public Guid SeriesItemId { get; set; }
    
    public SeriesItem? Series { get; set; }
    public List<EpisodeItem> Episodes { get; set; } = new();
}