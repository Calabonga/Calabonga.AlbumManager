namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Represents a view for items that can be processed before show in <see cref="AlbumManager"/>
/// </summary>
public interface IImageView
{
    IEnumerable<AlbumItem> Items { get; }
}