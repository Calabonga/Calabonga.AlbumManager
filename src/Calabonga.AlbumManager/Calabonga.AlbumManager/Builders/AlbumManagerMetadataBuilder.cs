using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public interface IAlbumManagerMetadataBuilder
{
    IAlbumManagerEditorBuilder AddMetadataReader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

internal class AlbumManagerMetadataBuilder : IAlbumManagerMetadataBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerMetadataBuilder(ICreator creator) => _creator = creator;

    public IAlbumManagerEditorBuilder AddMetadataReader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerEditorBuilder(_creator);
    }
}