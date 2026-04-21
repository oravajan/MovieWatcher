namespace MovieWatcher.Core.Entities;

/// <summary>
/// Represents a streaming platform or VOD service (e.g. Netflix).
/// </summary>
public class PlatformItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public List<MediaItem> MediaItems { get; set; } = new();
}