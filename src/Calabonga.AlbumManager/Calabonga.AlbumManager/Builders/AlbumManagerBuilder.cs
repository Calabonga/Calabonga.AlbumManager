using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public sealed class AlbumManagerBuilder<TCreator, TConfiguration>
    where TCreator : IAlbumManagerCreator
    where TConfiguration : IConfiguration, new()
{
    private IAlbumManagerCreator _albumManagerCreator = null!;

    public IAlbumManagerViewerBuilder AddCreator(Action<ICreatorConfiguration> configuration)
    {
        var config = new TConfiguration();
        configuration(config.CreatorConfiguration);
        _albumManagerCreator = (TCreator)Activator.CreateInstance(typeof(TCreator), config.CreatorConfiguration)!;

        return new AlbumManagerViewerBuilder(config, _albumManagerCreator);
    }
}