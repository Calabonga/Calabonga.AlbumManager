using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Interface abstraction for image processing pipeline.
/// </summary>
public interface IImageProcessor
{
    /// <summary>
    /// Execute processing for <see cref="AlbumImage"/>.
    /// </summary>
    /// <param name="imageInfo"></param>
    /// <param name="viewerConfiguration"></param>
    Task ProcessAsync(AlbumImage imageInfo, IViewerConfiguration viewerConfiguration);
}