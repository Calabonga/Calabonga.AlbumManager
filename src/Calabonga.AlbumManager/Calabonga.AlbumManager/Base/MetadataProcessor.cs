using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

public abstract class MetadataProcessor<TItem> : IMetadataProcessor
    where TItem : ItemBase
{
    public abstract Task ProcessAsync(TItem item, CancellationToken cancellationToken);
}