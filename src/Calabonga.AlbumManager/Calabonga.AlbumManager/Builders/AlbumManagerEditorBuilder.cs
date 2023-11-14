using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
public interface IAlbumManagerEditorBuilder
{
    /// <summary>
    /// calabonga
    /// </summary>
    /// <typeparam name="TCreatorConfiguration"></typeparam>
    /// <param name="configuration"></param>
    IAlbumManagerUploaderBuilder AddEditor<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
internal sealed class AlbumManagerEditorBuilder : IAlbumManagerEditorBuilder
{
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerEditorBuilder(IAlbumManagerCreator albumManagerCreator) => _albumManagerCreator = albumManagerCreator;

    public IAlbumManagerUploaderBuilder AddEditor<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerUploaderBuilder(_albumManagerCreator);
    }
}