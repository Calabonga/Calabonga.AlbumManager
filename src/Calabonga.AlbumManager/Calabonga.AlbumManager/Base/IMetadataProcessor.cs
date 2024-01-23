using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager.Base
{
    /// <summary>
    /// Interface abstraction for metadata processor registration in processing pipeline.
    /// </summary>
    public interface IMetadataProcessor { }

    /// <summary>
    /// Generic interface abstraction for metadata processor registration in processing pipeline <see cref="AlbumManager{TItem}"/>.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public interface IMetadataProcessor<in TItem> : IMetadataProcessor
        where TItem : ItemBase
    {
        /// <summary>
        /// Starts to search data for <see cref="TItem"/> in some place for processing as metadata for concrete item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        Task FindDataProcessAsync(TItem item, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes a data for <see cref="TItem"/> if metadata has been found for concrete item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken"></param>
        Task<DeleteResult> DeleteDataProcessAsync(TItem item, CancellationToken cancellationToken);
    }
}