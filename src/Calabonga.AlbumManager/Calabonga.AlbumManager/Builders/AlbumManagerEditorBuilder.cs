using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
internal sealed class AlbumManagerEditorBuilder : IAlbumManagerEditorBuilder
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerEditorBuilder(IConfiguration configuration, IAlbumManagerCreator albumManagerCreator)
    {
        _configuration = configuration;
        _albumManagerCreator = albumManagerCreator;
    }

    public IAlbumManagerUploaderBuilder AddEditor(Action<IEditorConfiguration> configuration)
    {
        configuration(_configuration.EditorConfiguration);
        return new AlbumManagerUploaderBuilder(_configuration, _albumManagerCreator);
    }
}