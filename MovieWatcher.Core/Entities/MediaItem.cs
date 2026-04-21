namespace MovieWatcher.Core.Entities;

/// <summary>
/// Base class for all tracked media items.
/// </summary>
public abstract class MediaItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public string? CsfdUrl { get; set; }
    public DateTime? LastSyncedAt { get; set; }
    public List<PlatformItem> Platforms { get; set; } = new();
}