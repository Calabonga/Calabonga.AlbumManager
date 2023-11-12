using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
public interface IAlbumManagerViewerBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder) 
    /// </summary>
    /// <typeparam name="TCreatorConfiguration"></typeparam>
    /// <param name="configuration"></param>
    IAlbumManagerMetadataBuilder AddViewer<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
internal sealed class AlbumManagerViewerBuilder : IAlbumManagerViewerBuilder
{
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerViewerBuilder(IAlbumManagerCreator albumManagerCreator) => _albumManagerCreator = albumManagerCreator;

    public IAlbumManagerMetadataBuilder AddViewer<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerMetadataBuilder(_albumManagerCreator);
    }
}