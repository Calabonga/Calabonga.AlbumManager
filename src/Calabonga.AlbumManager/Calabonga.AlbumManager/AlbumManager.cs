using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Viewers;
using System.Text;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager
{
    internal AlbumManager(IEnumerable<AlbumItem> items) => Items = items.ToList();

    /// <summary>
    /// Collected images
    /// </summary>
    private List<AlbumItem> Items { get; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder("AlbumManager Configuration");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"Total Items: {Items.Count}");

        return stringBuilder.ToString();
    }

    public IImageView GetView() => new DefaultImageView(Items);
}