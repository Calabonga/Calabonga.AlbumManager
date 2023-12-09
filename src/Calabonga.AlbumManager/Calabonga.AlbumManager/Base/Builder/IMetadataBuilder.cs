using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder) 
/// </summary>
public interface IMetadataBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerMetadataBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IEditorBuilder<TItem> AddMetadataReader<TMetadataConfiguration>(Action<TMetadataConfiguration> configuration);
}