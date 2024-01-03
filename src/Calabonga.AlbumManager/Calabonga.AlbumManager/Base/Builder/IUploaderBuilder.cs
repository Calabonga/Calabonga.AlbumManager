using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: Summary required (IUploaderBuilder 2024-01-03 09:39)
/// </summary>
/// <typeparam name="TItem"></typeparam>
public interface IUploaderBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IFinalBuilder<TItem> AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration);
}