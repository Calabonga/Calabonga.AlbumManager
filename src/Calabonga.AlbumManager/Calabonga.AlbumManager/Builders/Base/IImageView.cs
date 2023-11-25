namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Represents a view for items that can be processed before show in <see cref="AlbumManager"/>
/// </summary>
public interface IImageView<TItem>

{
    /// <summary>
    /// Returns items prepared for view
    /// </summary>
    IEnumerable<TItem> Items { get; }
}