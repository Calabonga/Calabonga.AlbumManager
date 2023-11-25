using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem>
{
    internal AlbumManager(IEnumerable<TItem> items) => Items = items.ToList();

    /// <summary>
    /// Collected images
    /// </summary>
    private List<TItem> Items { get; }

    public IImageView<TItem> GetView() => new DefaultImageView<TItem>(Items);
}