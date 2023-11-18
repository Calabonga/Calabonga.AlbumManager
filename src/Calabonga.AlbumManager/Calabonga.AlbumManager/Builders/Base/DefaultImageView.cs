using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Images view as default without any images pre- and postprocessing 
/// </summary>
public class DefaultImageView : IImageView
{
    public DefaultImageView(IEnumerable<AlbumItem> items) => Items = items;

    /// <summary>
    /// Returns items prepared for view
    /// </summary>
    public IEnumerable<AlbumItem> Items { get; }
}