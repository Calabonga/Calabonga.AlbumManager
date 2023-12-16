using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// // Calabonga: update summary (2023-12-09 08:40 DefaultImageView)
/// </summary>
public interface IImageProcessor
{
    /// <summary>
    /// Execute processing for item
    /// </summary>
    /// <param name="imageInfo"></param>
    Task ProcessAsync(AlbumImage imageInfo);
}