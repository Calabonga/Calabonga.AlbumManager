using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Default creator functionality for images
/// </summary>
public abstract class AlbumBuilderBase<TConfiguration, TItem> : IAlbumBuilder<TItem>
    where TConfiguration : IConfiguration
    where TItem : class
{
    protected AlbumBuilderBase(TConfiguration configuration)
        => Configuration = configuration;

    /// <summary>
    /// Configuration for current type of manager
    /// </summary>
    protected TConfiguration Configuration { get; }

    /// <summary>
    /// Returns a collection for <see cref="TItem"/> found in location provided
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerable<TItem> GetItems();
}