using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem> : IAlbumManager<TItem>
    where TItem : ItemBase
{


    internal AlbumManager(IPagedList<TItem> items, IAlbumBuilder<TItem> albumBuilder, IConfiguration configuration)
    {
        AlbumBuilder = albumBuilder;
        Configuration = configuration;
        PagedList = items;
    }

    public IEnumerable<string> Commands
        => Configuration.CommanderConfiguration.CommandProcessor?.GetCommands()
           ?? Enumerable.Empty<string>();

    /// <summary>
    /// PagedList in <see cref="AlbumManager{TItem}"/> founded for managing.
    /// </summary>
    public IPagedList<TItem> PagedList { get; private set; }

    /// <summary>
    /// AlbumBuilder that's can rebuild collection founded in folders.
    /// </summary>
    public IAlbumBuilder<TItem> AlbumBuilder { get; }

    /// <summary>
    /// Remove from collected items and delete image-file
    /// </summary>
    /// <param name="item"></param>
    public void Remove(TItem item) => PagedList.Items.Remove(item);

    /// <summary>
    /// Updates collection of the items for current <see cref="AlbumManager{TItem}"/>
    /// </summary>
    /// <param name="items">items for replacing</param>
    public void SetItems(IPagedList<TItem> items) => PagedList = items;

    /// <summary>
    /// Configuration used for files processing
    /// </summary>
    public IConfiguration Configuration { get; }
    public Task<TResult?> ExecuteAsync<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand<TResult?>
    {
        if (Configuration.CommanderConfiguration.CommandProcessor?.GetCommands() is not null)
        {
            Configuration.CommanderConfiguration.CommandProcessor.SetAlbumManager(this);
            return Configuration.CommanderConfiguration.CommandProcessor.Execute<TResult?, TCommand>(command, cancellationToken);
        }
        else
        {
            return Task.FromResult<TResult?>(default);
        }
    }
}