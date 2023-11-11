using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public interface IAlbumManagerViewerBuilder
{
    IAlbumManagerMetadataBuilder AddViewer<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

internal class AlbumManagerViewerBuilder : IAlbumManagerViewerBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerViewerBuilder(ICreator creator) => _creator = creator;

    public IAlbumManagerMetadataBuilder AddViewer<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerMetadataBuilder(_creator);
    }
}