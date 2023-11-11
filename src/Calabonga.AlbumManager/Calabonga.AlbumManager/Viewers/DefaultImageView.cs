using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Viewers;

/// <summary>
/// // Calabonga: update summary (2023-10-28 11:26 DefaultImageView)
/// </summary>
public class DefaultImageView : IImageView
{
    public DefaultImageView(IEnumerable<AlbumItem> items)
    {
        Items = items;
    }

    public IEnumerable<AlbumItem> Items { get; }
}