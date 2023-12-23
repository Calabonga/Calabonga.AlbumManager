using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

public abstract class MetadataProcessor<TItem> : IMetadataProcessor
    where TItem : ItemBase
{
    public abstract Task FindDataProcessAsync(TItem item, CancellationToken cancellationToken);

    public abstract Task<bool> DeleteDataProcessAsync(TItem item, CancellationToken cancellationToken);
}