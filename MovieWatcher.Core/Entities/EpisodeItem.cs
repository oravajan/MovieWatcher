namespace MovieWatcher.Core.Entities;

/// <summary>
/// Represents a single episode within a season.
/// </summary>
public class EpisodeItem
{
    public Guid Id { get; set; }
    public int EpisodeNumber { get; set; }
    public bool IsWatched { get; set; }
    public Guid SeasonItemId { get; set; }
    
    public SeasonItem? Season { get; set; }
}