namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:19 ICreator)
/// </summary>
public interface IAlbumBuilder<TItem>
    where TItem : class
{
    Task<List<TItem>> GetItemsAsync(CancellationToken cancellationToken);
}