namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
public interface IAlbumManagerViewerBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder) 
    /// </summary>
    /// <param name="configuration"></param>
    IAlbumManagerMetadataBuilder AddViewer(Action<IViewerConfiguration> configuration);
}