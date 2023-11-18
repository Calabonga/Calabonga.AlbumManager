using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerBuilderResult)
/// </summary>
internal sealed class AlbumManagerFinalBuilder : IFinalBuilder
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumManagerCreator _albumManagerCreator;

    public AlbumManagerFinalBuilder(IConfiguration configuration, IAlbumManagerCreator albumManagerCreator)
    {
        _configuration = configuration;
        _albumManagerCreator = albumManagerCreator;
    }

    public AlbumManager Build()
    {
        var items = _albumManagerCreator.GetItems();
        var manager = new AlbumManager(items);
        return manager;
    }
}