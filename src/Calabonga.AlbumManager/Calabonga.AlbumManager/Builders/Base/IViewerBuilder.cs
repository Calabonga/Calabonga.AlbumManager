namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
public interface IViewerBuilder<TItem>
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder) 
    /// </summary>
    /// <param name="configuration"></param>
    IMetadataBuilder<TItem> AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration);
}