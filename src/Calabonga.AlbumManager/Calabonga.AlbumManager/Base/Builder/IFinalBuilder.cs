using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Interface abstraction for configuration final step.
/// </summary>
public interface IFinalBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// The final step for <see cref="AlbumManager{TItem}"/> configuration and generation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>an instance <see cref="AlbumManager{TItem}"/> </returns>
    Task<AlbumManager<TItem>> BuildAsync(CancellationToken cancellationToken);
}