using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public class AlbumManagerViewerBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerViewerBuilder(ICreator creator) => _creator = creator;

    public AlbumManagerMetadataBuilder AddViewer<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerMetadataBuilder(_creator);
    }
}