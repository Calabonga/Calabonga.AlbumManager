using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Base abstraction for metadata processor registration in processing pipeline <see cref="AlbumManager{TItem}"/>.
/// </summary>
/// <typeparam name="TItem"></typeparam>
public abstract class MetadataProcessor<TItem> : IMetadataProcessor<TItem>
    where TItem : ItemBase
{
    /// <summary>
    /// Starts to search data for <see cref="TItem"/> in some place for processing as metadata for concrete item.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    public abstract Task FindDataProcessAsync(TItem item, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a data for <see cref="TItem"/> if metadata has been found for concrete item.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    public abstract Task<DeleteResult> DeleteDataProcessAsync(TItem item, CancellationToken cancellationToken);
}