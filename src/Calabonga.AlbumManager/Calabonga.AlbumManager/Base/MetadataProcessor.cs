using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

public abstract class MetadataProcessor<TItem> : IMetadataProcessor<TItem>
    where TItem : ItemBase
{
    public abstract Task FindDataProcessAsync(TItem item, CancellationToken cancellationToken);

    public abstract Task<DeleteResult> DeleteDataProcessAsync(TItem item, CancellationToken cancellationToken);
}