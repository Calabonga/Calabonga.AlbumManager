namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Default creator functionality for images
/// </summary>
public abstract class AlbumCreatorBase<TConfiguration> : ICreator
{
    protected AlbumCreatorBase(TConfiguration configuration)
        => Configuration = configuration;

    public TConfiguration Configuration { get; }

    public abstract IEnumerable<AlbumItem> GetItems();
}