using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public interface IAlbumManagerEditorBuilder
{
    IAlbumManagerUploaderBuilder AddEditor<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

internal class AlbumManagerEditorBuilder : IAlbumManagerEditorBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerEditorBuilder(ICreator creator) => _creator = creator;

    public IAlbumManagerUploaderBuilder AddEditor<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerUploaderBuilder(_creator);
    }
}