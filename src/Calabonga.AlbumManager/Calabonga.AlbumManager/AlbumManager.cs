using System.Text;
using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager
{
    private readonly AlbumCreatorBase _albumCreator;

    internal AlbumManager(AlbumCreatorBase albumCreator)
    {
        _albumCreator = albumCreator;
        Items = _albumCreator.GetItems();
    }

    private List<AlbumItem> Items { get; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder("AlbumManager Configuration");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine($"AlbumCreator: {_albumCreator.GetType().Name}");
        stringBuilder.AppendLine($"Total Items: {Items.Count}");

        return stringBuilder.ToString();
    }

    public IImageView GetView()
    {
        return new DefaultImageView(Items);
    }
}