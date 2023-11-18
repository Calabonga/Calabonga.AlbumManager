namespace Calabonga.AlbumsManager.Models;

/// <summary>
/// Represents a image metadata for item that found in folder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumItem
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:36 AlbumItem)
    /// </summary>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:36 AlbumItem)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:37 AlbumItem)
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:37 AlbumItem)
    /// </summary>
    public string? DirectoryName { get; set; }

    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:37 AlbumItem)
    /// </summary>
    public IEnumerable<AlbumItem>? Items { get; set; }
}