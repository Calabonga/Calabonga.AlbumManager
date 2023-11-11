namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Default creator functionality for images
/// </summary>
public abstract class AlbumCreatorBase<TConfiguration> : ICreator
{
    protected AlbumCreatorBase(TConfiguration configuration)
        => Configuration = configuration;

    /// <summary>
    /// Configuration for current type of manager
    /// </summary>
    protected TConfiguration Configuration { get; }

    /// <summary>
    /// Returns a collection for <see cref="AlbumItem"/> found in location provided
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerable<AlbumItem> GetItems();
}