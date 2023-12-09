using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:14 AlbumManagerBuilderResult)
/// </summary>
public interface IFinalBuilder<TItem> where TItem : ItemBase
{
    AlbumManager<TItem> Build();
}