using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
internal sealed class AlbumManagerViewerBuilder : IAlbumManagerViewerBuilder
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerViewerBuilder(IConfiguration configuration, IAlbumManagerCreator albumManagerCreator)
    {
        _configuration = configuration;
        _albumManagerCreator = albumManagerCreator;
    }

    public IAlbumManagerMetadataBuilder AddViewer(Action<IViewerConfiguration> configuration)
    {
        configuration(_configuration.ViewerConfiguration);
        return new AlbumManagerMetadataBuilder(_configuration, _albumManagerCreator);
    }
}