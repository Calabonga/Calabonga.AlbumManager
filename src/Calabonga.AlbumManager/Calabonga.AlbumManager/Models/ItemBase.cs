namespace Calabonga.AlbumsManager.Models;

/// <summary>
/// // Calabonga: update summary (2023-12-09 04:47 ItemBase)
/// </summary>
public abstract class ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:36 AlbumItem)
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:36 AlbumItem)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// // Calabonga: update summary (2023-12-09 02:45 AlbumImage)
    /// </summary>
    public virtual bool CanBeProcessed => true;

    public virtual bool HasItems => false;
}