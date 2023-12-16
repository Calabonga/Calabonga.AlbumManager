using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.ImageProcessors;

/// <summary>
/// // Calabonga: update summary (2023-12-09 08:40 DefaultImageView)
/// </summary>
public interface IImageProcessor
{
    /// <summary>
    /// Execute processing for item
    /// </summary>

    /// <param name="imageInfo"></param>
    void Process(AlbumImage imageInfo);
}