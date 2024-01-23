using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;

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

    /// <summary>
    /// Starts processing pipeline for current page
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public virtual async Task<IPagedList<TItem>> GetItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var createdItems = await ExecuteCreateAsync(cancellationToken);
        var metadataItems = await ExecuteMetadataAsync(createdItems, cancellationToken);
        var viewedItems = await ExecuteViewerAsync(metadataItems, cancellationToken);

        return viewedItems;
    }

    /// <summary>
    /// Returns a collection for <see cref="TItem"/> found in location provided
    /// </summary>
    /// <returns>items found</returns>
    protected virtual Task<IPagedList<TItem>> ExecuteCreateAsync(CancellationToken cancellationToken)
        => Task.FromResult(PagedList.Empty<TItem>());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createdItems"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>updated with metadata items as paged list</returns>
    protected virtual async Task<IPagedList<TItem>> ExecuteMetadataAsync(IPagedList<TItem> createdItems, CancellationToken cancellationToken)
    {
        if (Configuration.MetadataConfiguration.MetadataProcessor is null)
        {
            return createdItems;
        }

        if (Configuration.MetadataConfiguration.MetadataProcessor is MetadataProcessor<TItem> processor)
        {
            foreach (var loadedItem in createdItems.Items)
            {
                await processor.FindDataProcessAsync(loadedItem, cancellationToken);
            }
        }

        return createdItems;
    }

    /// <summary>
    /// Starts preparing metadata for items
    /// </summary>
    /// <param name="metadataItems"></param>
    /// <param name="cancellationToken"></param>
    protected virtual async Task<IPagedList<TItem>> ExecuteViewerAsync(IPagedList<TItem> metadataItems, CancellationToken cancellationToken)
    {
        if (!Configuration.ViewerConfiguration.ImageProcessors.Any())
        {
            return metadataItems;
        }

        foreach (var item in metadataItems.Items)
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
            await processor.ProcessAsync((AlbumImage)item, viewerConfiguration);
        }
    }
}