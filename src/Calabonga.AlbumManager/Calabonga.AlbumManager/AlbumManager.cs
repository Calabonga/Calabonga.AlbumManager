using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem>
    where TItem : ItemBase
{
    internal AlbumManager(IEnumerable<TItem> items, IConfiguration configuration)
    {
        Configuration = configuration;
        Items = items;

    }

    public IEnumerable<TItem> Items { get; }

    /// <summary>
    /// Configuration used for files processing
    /// </summary>
    public IConfiguration Configuration { get; }
}