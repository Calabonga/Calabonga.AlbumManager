namespace Calabonga.AlbumsManager;

/// <summary>
/// Represents a image metadata for item that found in folder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumItem
{
    public string FileName { get; set; } = null!;

    public string? Description { get; set; }

    public long FileSize { get; set; }

    public string? DirectoryName { get; set; }

    public IEnumerable<AlbumItem>? Items { get; set; }
}