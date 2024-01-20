using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;


/// <summary>
/// Default implementation final builder for configuration final step.
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

    /// <summary>
    /// The final step for <see cref="AlbumManager{TItem}"/> configuration and generation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>an instance <see cref="AlbumManager{TItem}"/> </returns>
    public async Task<AlbumManager<TItem>> BuildAsync(CancellationToken cancellationToken = default)
    {
        var pageIndex = _configuration.CreatorConfiguration.PageIndex;
        var pageSize = _configuration.CreatorConfiguration.PageSize;
        var items = await _albumBuilder.GetItemsAsync(pageIndex, pageSize, cancellationToken);
        var manager = new AlbumManager<TItem>(items, _albumBuilder, _configuration);
        return manager;
    }
}