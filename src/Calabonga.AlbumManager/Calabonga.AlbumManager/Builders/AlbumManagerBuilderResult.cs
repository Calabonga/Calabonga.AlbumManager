using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:14 AlbumManagerBuilderResult)
/// </summary>
public interface IAlbumManagerBuilderResult
{
    AlbumManager Build();
}

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerBuilderResult)
/// </summary>
internal sealed class AlbumManagerBuilderResult : IAlbumManagerBuilderResult
{
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerBuilderResult(IAlbumManagerCreator albumManagerCreator) => _albumManagerCreator = albumManagerCreator;

    public AlbumManager Build()
    {
        var items = _albumManagerCreator.GetItems();
        var manager = new AlbumManager(items);
        return manager;
    }
}