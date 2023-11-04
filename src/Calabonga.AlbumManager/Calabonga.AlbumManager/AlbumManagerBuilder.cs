using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager;
/// <summary>
/// Configuration builder for <see cref="AlbumManager"/>
/// </summary>
public class AlbumManagerBuilder
{
    private ICreator _creator = null!;

    public void AddCreator<TCreator, TConfiguration>(Action<TConfiguration> configuration)
        where TCreator : AlbumCreatorBase<TConfiguration>
        where TConfiguration : class, new()
    {
        var config = new TConfiguration();
        configuration(config);
        _creator = (AlbumCreatorBase<TConfiguration>)Activator.CreateInstance(typeof(TCreator), config)!;
    }

    public AlbumManager Build()
    {
        var items = _creator.GetItems();
        var manager = new AlbumManager(items);
        return manager;
    }
}