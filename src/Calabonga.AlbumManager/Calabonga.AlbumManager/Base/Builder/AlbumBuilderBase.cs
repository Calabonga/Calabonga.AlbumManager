using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Default creator functionality for images
/// </summary>
public abstract class AlbumBuilderBase<TConfiguration, TItem> : IAlbumBuilder<TItem>
    where TConfiguration : IConfiguration
    where TItem : ItemBase
{
    protected AlbumBuilderBase(TConfiguration configuration)
        => Configuration = configuration;

    /// <summary>
    /// Configuration for current type of manager
    /// </summary>
    protected TConfiguration Configuration { get; }

    public virtual async Task<List<TItem>> GetItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var createdItems = await ExecuteCreateAsync(cancellationToken);
        var metadataItems = await ExecuteMetadataAsync(createdItems.ToList(), cancellationToken);
        var viewedItems = await ExecuteViewerAsync(metadataItems, cancellationToken);

        return viewedItems;
    }

    /// <summary>
    /// Returns a collection for <see cref="TItem"/> found in location provided
    /// </summary>
    /// <returns></returns>
    protected virtual Task<List<TItem>> ExecuteCreateAsync(CancellationToken cancellationToken)
        => Task.FromResult(new List<TItem>());

    protected virtual async Task<List<TItem>> ExecuteMetadataAsync(List<TItem> createdItems, CancellationToken cancellationToken)
    {
        if (Configuration.MetadataConfiguration.MetadataProcessor is null)
        {
            return createdItems;
        }

        if (Configuration.MetadataConfiguration.MetadataProcessor is MetadataProcessor<TItem> processor)
        {
            foreach (var loadedItem in createdItems)
            {

                await processor.FindDataProcessAsync(loadedItem, cancellationToken);
            }
        }

        return createdItems;
    }

    protected virtual async Task<List<TItem>> ExecuteViewerAsync(List<TItem> metadataItems, CancellationToken cancellationToken)
    {
        if (!Configuration.ViewerConfiguration.ImageProcessors.Any())
        {
            return metadataItems;
        }

        foreach (var item in metadataItems)
        {
            if (!item.CanBeProcessed)
            {
                if (item.HasItems)
                {
                    var innerItems = (item as AlbumDirectory)?.Items ?? new List<AlbumImage>();
                    foreach (var innerItem in innerItems)
                    {
                        await ExecuteProcessingAsync(Configuration.ViewerConfiguration, innerItem, cancellationToken);
                    }
                }
                continue;
            }

            await ExecuteProcessingAsync(Configuration.ViewerConfiguration, item, cancellationToken);
        }

        return metadataItems;
    }

    private async Task ExecuteProcessingAsync(IViewerConfiguration viewerConfiguration, ItemBase item, CancellationToken cancellationToken)
    {
        foreach (var processor in viewerConfiguration.ImageProcessors)
        {
            await processor.ProcessAsync((AlbumImage)item);
        }
    }
}