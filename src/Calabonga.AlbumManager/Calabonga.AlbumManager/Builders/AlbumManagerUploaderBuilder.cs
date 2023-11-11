using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public interface IAlbumManagerUploaderBuilder
{
    IAlbumManagerBuilderResult AddUploader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration);
}

internal class AlbumManagerUploaderBuilder : IAlbumManagerUploaderBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerUploaderBuilder(ICreator creator) => _creator = creator;

    public IAlbumManagerBuilderResult AddUploader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerBuilderResult(_creator);
    }
}