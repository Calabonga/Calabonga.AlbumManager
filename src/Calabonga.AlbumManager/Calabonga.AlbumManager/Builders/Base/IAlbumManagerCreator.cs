using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:19 ICreator)
/// </summary>
public interface IAlbumManagerCreator
{
    IEnumerable<AlbumItem> GetItems();
}