namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder) 
/// </summary>
public interface IAlbumManagerMetadataBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IAlbumManagerEditorBuilder AddMetadataReader(Action<IMetadataConfiguration> configuration);
}