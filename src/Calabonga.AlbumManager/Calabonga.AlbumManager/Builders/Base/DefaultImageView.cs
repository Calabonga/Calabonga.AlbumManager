namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Images view as default without any images pre- and postprocessing 
/// </summary>
public class DefaultImageView<TItem> : IImageView<TItem>
{
    public DefaultImageView(IEnumerable<TItem> items) => Items = items;

    /// <summary>
    /// Returns items prepared for view
    /// </summary>
    public IEnumerable<TItem> Items { get; }
}