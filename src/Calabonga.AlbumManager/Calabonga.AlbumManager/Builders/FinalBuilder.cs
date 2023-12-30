using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;
/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerBuilderResult)
/// </summary>
internal sealed class FinalBuilder<TItem> : IFinalBuilder<TItem>
    where TItem : ItemBase
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public FinalBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public async Task<AlbumManager<TItem>> BuildAsync(CancellationToken cancellationToken = default)
    {
        var items = await _albumBuilder.GetItemsAsync(0, 0, cancellationToken);
        var manager = new AlbumManager<TItem>(items, _albumBuilder, _configuration);
        return manager;
    }
}