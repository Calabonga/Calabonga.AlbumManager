using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Base.Viewer;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem>
    where TItem : ItemBase
{
    private readonly DefaultImageView<TItem> _view;

    internal AlbumManager(IEnumerable<TItem> items, IConfiguration configuration)
    {
        Configuration = configuration;
        _view = new DefaultImageView<TItem>(items);

    }
    /// <summary>
    /// Configuration used for files processing
    /// </summary>
    public IConfiguration Configuration { get; }

    public IEnumerable<TItem> GetView()
        => _view
            .Process(Configuration.ViewerConfiguration)
            .Items;
}