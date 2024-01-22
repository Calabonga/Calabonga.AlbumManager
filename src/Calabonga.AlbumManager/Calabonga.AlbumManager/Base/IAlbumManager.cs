using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;

namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Global interface for dependency injection and other manipulations.
/// </summary>
public interface IAlbumManager
{
    /// <summary>
    /// Global interface configuration for &lt;see cref="AlbumManager{TItem}"/&gt; processing pipelines.
    /// </summary>
    IConfiguration Configuration { get; }

    /// <summary>
    /// // Calabonga: Summary required (IAlbumManager 2024-01-22 09:40)
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TResult> ExecuteAsync<TResult, TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand<TResult>;
}

/// <summary>
/// Generic interface for dependency injection and other manipulations.
/// </summary>
/// <typeparam name="TItem"></typeparam>
public interface IAlbumManager<TItem> : IAlbumManager
    where TItem : ItemBase
{

    /// <summary>
    /// PagedList in <see cref="AlbumManager{TItem}"/> founded for managing.
    /// </summary>
    public IPagedList<TItem> PagedList { get; }

    /// <summary>
    /// AlbumBuilder that's can rebuild collection founded in folders.
    /// </summary>
    IAlbumBuilder<TItem> AlbumBuilder { get; }

    /// <summary>
    /// Remove from collected items and delete image-file
    /// </summary>
    /// <param name="item"></param>
    void Remove(TItem item);

    /// <summary>
    /// Updates collection of the items for current <see cref="AlbumManager{TItem}"/>
    /// </summary>
    /// <param name="items">items for replacing</param>
    void SetItems(IPagedList<TItem> items);
}