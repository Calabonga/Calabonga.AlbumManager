using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
internal sealed class EditorBuilder<TItem> : IEditorBuilder<TItem>
    where TItem : class
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public EditorBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public IUploaderBuilder<TItem> AddEditor(Action<IEditorConfiguration> configuration)
    {
        configuration(_configuration.EditorConfiguration);
        return new UploaderBuilder<TItem>(_configuration, _albumBuilder);
    }
}