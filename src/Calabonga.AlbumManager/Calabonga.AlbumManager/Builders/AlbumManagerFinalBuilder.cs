using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerBuilderResult)
/// </summary>
internal sealed class FinalBuilder<TItem> : IFinalBuilder<TItem>
    where TItem : class
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public FinalBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public AlbumManager<TItem> Build()
    {
        var items = _albumBuilder.GetItems();
        var manager = new AlbumManager<TItem>(items, _configuration);
        return manager;
    }
}