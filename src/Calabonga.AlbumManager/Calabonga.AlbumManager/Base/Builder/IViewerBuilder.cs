using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
public interface IViewerBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder) 
    /// </summary>
    /// <param name="configuration"></param>
    IMetadataBuilder<TItem> AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration);
}