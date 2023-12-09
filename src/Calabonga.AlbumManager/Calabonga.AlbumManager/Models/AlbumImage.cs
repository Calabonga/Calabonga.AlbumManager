namespace Calabonga.AlbumsManager.Models;

public class AlbumImage : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:37 AlbumItem)
    /// </summary>
    public long FileSize { get; set; }

    public byte[]? OriginalBytes { get; set; }

    public byte[]? ProcessedBytes { get; set; }
}