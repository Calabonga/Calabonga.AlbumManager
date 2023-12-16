using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Viewer;

/// <summary>
/// Images view as default without any images pre- and postprocessing 
/// </summary>
public class DefaultImageView<TItem> : IImageView<TItem>
    where TItem : ItemBase
{
    public DefaultImageView(IEnumerable<TItem> items) => Items = items;

    /// <summary>
    /// Returns items prepared for view
    /// </summary>
    public IEnumerable<TItem> Items { get; }

    public DefaultImageView<TItem> Process(IViewerConfiguration viewerConfiguration)
    {
        if (!viewerConfiguration.ImageProcessors.Any())
        {
            return this;
        }

        foreach (var item in Items)
        {
            if (!item.CanBeProcessed)
            {
                if (item.HasItems)
                {
                    var innerItems = (item as AlbumDirectory)?.Items ?? new List<AlbumImage>();
                    foreach (var innerItem in innerItems)
                    {
                        ExecuteProcessing(viewerConfiguration, innerItem);
                    }
                }
                continue;
            }

            ExecuteProcessing(viewerConfiguration, item);
        }

        return this;
    }

    private void ExecuteProcessing(IViewerConfiguration viewerConfiguration, ItemBase item)
    {
        foreach (var processor in viewerConfiguration.ImageProcessors)
        {
            processor.Process((AlbumImage)item);
        }
    }
}

