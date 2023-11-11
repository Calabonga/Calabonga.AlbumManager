using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public class AlbumManagerUploaderBuilder
{
    private readonly ICreator _creator;

    public AlbumManagerUploaderBuilder(ICreator creator) => _creator = creator;

    public AlbumManagerBuilderResult AddUploader<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
    {
        return new AlbumManagerBuilderResult(_creator);
    }
}