using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.Builders;

public interface IAlbumManagerBuilderResult
{
    AlbumManager Build();
}

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