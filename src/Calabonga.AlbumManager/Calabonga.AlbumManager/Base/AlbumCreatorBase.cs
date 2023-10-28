namespace Calabonga.AlbumsManager.Base;

/// <summary>
/// Default creator functionality for images
/// </summary>
public abstract class AlbumCreatorBase
{
    public abstract List<AlbumItem> GetItems();
}