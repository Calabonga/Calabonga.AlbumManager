using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public class AlbumManagerEditorBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerEditorBuilder(ICreator creator) => _creator = creator;

    public AlbumManagerUploaderBuilder AddEditor<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerUploaderBuilder(_creator);
    }
}