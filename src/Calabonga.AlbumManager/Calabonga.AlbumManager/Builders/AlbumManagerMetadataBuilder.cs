using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public class AlbumManagerMetadataBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerMetadataBuilder(ICreator creator) => _creator = creator;

    public AlbumManagerEditorBuilder AddMetadataReader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerEditorBuilder(_creator);
    }
}