namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:19 ICreator)
/// </summary>
public interface IAlbumBuilder<out TItem>
    where TItem : class
{
    IEnumerable<TItem> GetItems();
}