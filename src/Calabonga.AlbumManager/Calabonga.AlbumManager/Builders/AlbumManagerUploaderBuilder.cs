using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
/// </summary>
internal sealed class AlbumManagerUploaderBuilder : IAlbumManagerUploaderBuilder
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerUploaderBuilder(IConfiguration configuration, IAlbumManagerCreator albumManagerCreator)
    {
        _configuration = configuration;
        _albumManagerCreator = albumManagerCreator;
    }

    public IFinalBuilder AddUploader(Action<IUploaderConfiguration> configuration)
    {
        configuration(_configuration.UploaderConfiguration);
        return new AlbumManagerFinalBuilder(_configuration, _albumManagerCreator);
    }
}