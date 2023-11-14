using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumManagerBuilder
{
    private ICreator _creator = null!;

    public IAlbumManagerViewerBuilder AddCreator<TCreator, TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
        where TCreator : AlbumCreatorBase<TCreatorConfiguration>
        where TCreatorConfiguration : class, new()
    {
        var config = new TCreatorConfiguration();
        configuration(config);
        _creator = (AlbumCreatorBase<TCreatorConfiguration>)Activator.CreateInstance(typeof(TCreator), config)!;

        return new AlbumManagerViewerBuilder(_creator);
    }
}