using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerMetadataBuilder)
/// </summary>
internal sealed class AlbumManagerMetadataBuilder : IAlbumManagerMetadataBuilder
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerMetadataBuilder(IConfiguration configuration, IAlbumManagerCreator albumManagerCreator)
    {
        _configuration = configuration;
        _albumManagerCreator = albumManagerCreator;
    }

    public IAlbumManagerEditorBuilder AddMetadataReader(Action<IMetadataConfiguration> configuration)
    {
        configuration(_configuration.MetadataConfiguration);
        return new AlbumManagerEditorBuilder(_configuration, _albumManagerCreator);
    }


}