using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Represents a view for items that can be processed before show in <see cref="AlbumManager"/>
/// </summary>
public interface IImageView
{
    /// <summary>
    /// Returns items prepared for view
    /// </summary>
    IEnumerable<AlbumItem> Items { get; }
}