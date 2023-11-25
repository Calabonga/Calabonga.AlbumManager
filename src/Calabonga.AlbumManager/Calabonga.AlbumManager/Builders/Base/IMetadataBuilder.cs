namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder) 
/// </summary>
public interface IMetadataBuilder<TItem>
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IEditorBuilder<TItem> AddMetadataReader(Action<IMetadataConfiguration> configuration);
}