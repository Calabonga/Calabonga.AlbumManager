using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.CommandProcessors;

/// <summary>
/// // Calabonga: Summary required (GetImageById 2023-12-18 05:05)
/// </summary>
/// <typeparam name="TItem"></typeparam>
public interface IAlbumManager<TItem> : IAlbumManager
{
    /// <summary>
    /// Items in <see cref="AlbumManager{TItem}"/> founded for managing.
    /// </summary>
    IEnumerable<TItem> Items { get; }

    /// <summary>
    /// Remove from collected items and delete image-file
    /// </summary>
    /// <param name="item"></param>
    void Remove(TItem item);
}