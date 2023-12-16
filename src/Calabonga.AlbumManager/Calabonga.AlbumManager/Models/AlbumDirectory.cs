namespace Calabonga.AlbumsManager.Models;

/// <summary>
/// Represents a image metadata for item that found in folder for <see cref="AlbumManager{TItem}"/>
/// </summary>
public class AlbumDirectory : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:37 AlbumItem)
    /// </summary>
    public IEnumerable<AlbumImage>? Items { get; set; }

    public override bool CanBeProcessed => false;

    /// <summary>
    /// // Calabonga: update summary and rename (2023-12-09 03:00 AlbumDirectory)
    /// </summary>
    public override bool HasItems => Items is not null && Items.Any();
}