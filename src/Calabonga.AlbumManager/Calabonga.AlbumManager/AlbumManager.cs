using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Photo and images Manager with some helpful processing
/// </summary>
public sealed class AlbumManager<TItem> : IAlbumManager<TItem>
    where TItem : ItemBase
{
    private List<TItem> _items;

    internal AlbumManager(IEnumerable<TItem> items, IAlbumBuilder<TItem> albumBuilder, IConfiguration configuration)
    {
        AlbumBuilder = albumBuilder;
        Configuration = configuration;
        _items = items.ToList();
    }

    public IEnumerable<string> Commands
        => Configuration.CommanderConfiguration.CommandProcessor?.GetCommands()
           ?? Enumerable.Empty<string>();

    /// <summary>
    /// Items in <see cref="AlbumManager{TItem}"/> founded for managing.
    /// </summary>
    public IEnumerable<TItem> Items => _items;

    /// <summary>
    /// AlbumBuilder that's can rebuild collection founded in folders.
    /// </summary>
    public IAlbumBuilder<TItem> AlbumBuilder { get; }

    /// <summary>
    /// Remove from collected items and delete image-file
    /// </summary>
    /// <param name="item"></param>
    public void Remove(TItem item) => _items.Remove(item);

    /// <summary>
    /// Updates collection of the items for current <see cref="AlbumManager{TItem}"/>
    /// </summary>
    /// <param name="items">items for replacing</param>
    public void SetItems(IEnumerable<TItem> items) => _items = items.ToList();

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