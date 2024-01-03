using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

public interface IMetadataProcessor<TItem> : IMetadataProcessor
    where TItem : ItemBase
{
    Task FindDataProcessAsync(TItem item, CancellationToken cancellationToken);

    Task<DeleteResult> DeleteDataProcessAsync(TItem item, CancellationToken cancellationToken);
}

public interface IMetadataProcessor { }