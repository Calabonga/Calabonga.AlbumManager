namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:14 AlbumManagerBuilderResult)
/// </summary>
public interface IFinalBuilder<TItem>
{
    AlbumManager<TItem> Build();
}