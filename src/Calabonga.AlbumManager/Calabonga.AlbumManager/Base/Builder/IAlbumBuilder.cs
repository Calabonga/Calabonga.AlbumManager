namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Interface for <see cref="AlbumManager{TItem}"/> items search in the folders.
/// </summary>
public interface IAlbumBuilder<TItem>
    where TItem : class
{
    /// <summary>
    /// Returns items that was found in the folder
    /// </summary>
    /// <param name="pageIndex">current page index</param>
    /// <param name="pageSize">page size for items</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>a list of items</returns>
    Task<List<TItem>> GetItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
}