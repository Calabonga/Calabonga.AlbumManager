using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager;
/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumManagerBuilder
{
    private AlbumCreatorBase _creator = null!;

    public void AddCreator(Action<FolderAlbumCreatorConfiguration> configuration)
    {
        var config = new FolderAlbumCreatorConfiguration();
        configuration(config);
        _creator = new FolderAlbumCreator(config);
    }

    public AlbumManager Build()
    {
        var manager = new AlbumManager(_creator);

        return manager;
    }
}