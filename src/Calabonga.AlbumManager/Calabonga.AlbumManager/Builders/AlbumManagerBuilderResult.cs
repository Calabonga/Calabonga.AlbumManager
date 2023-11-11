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
internal class AlbumManagerBuilderResult : IAlbumManagerBuilderResult
{
    private readonly ICreator _creator;

    public AlbumManagerBuilderResult(ICreator creator) => _creator = creator;

    public AlbumManager Build()
    {
        var items = _creator.GetItems();
        var manager = new AlbumManager(items);
        return manager;
    }
}