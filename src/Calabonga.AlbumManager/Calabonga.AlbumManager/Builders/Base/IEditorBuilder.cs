namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
public interface IEditorBuilder<TItem>
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:19 IAlbumManagerEditorBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IUploaderBuilder<TItem> AddEditor(Action<IEditorConfiguration> configuration);
}