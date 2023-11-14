using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public sealed class AlbumManagerBuilder<TCreator>
    where TCreator : IAlbumManagerCreator
{
    private IAlbumManagerCreator _albumManagerCreator = null!;

    public IAlbumManagerViewerBuilder AddCreator<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
        where TCreatorConfiguration : class, new()
    {
        var config = new TCreatorConfiguration();
        configuration(config);
        _albumManagerCreator = (AlbumManagerCreatorBase<TCreatorConfiguration>)Activator.CreateInstance(typeof(TCreator), config)!;

        return new AlbumManagerViewerBuilder(_albumManagerCreator);
    }
}