using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerUploaderBuilder)
/// </summary>
public interface IUploaderBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IFinalBuilder<TItem> AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration);
}