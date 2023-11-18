using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Folder.Configurations;

/// <summary>
/// Global interface configuration for Folder Album
/// </summary>
public class FolderAlbumConfiguration : IConfiguration
{
    /// <summary>
    /// Configuration for Creator processing
    /// </summary>
    public ICreatorConfiguration CreatorConfiguration { get; } = new FolderAlbumCreatorConfiguration();

    /// <summary>
    /// Configuration for Viewer processing
    /// </summary>
    public IViewerConfiguration ViewerConfiguration { get; } = new FolderAlbumViewerConfiguration();

    /// <summary>
    /// Configuration for Metadata processing
    /// </summary>
    public IMetadataConfiguration MetadataConfiguration { get; } = new FolderAlbumMetadataReaderConfiguration();

    /// <summary>
    /// Configuration for Editor processing
    /// </summary>
    public IEditorConfiguration EditorConfiguration { get; } = new FolderAlbumEditorConfiguration();

    /// <summary>
    /// Configuration for Uploader processing
    /// </summary>
    public IUploaderConfiguration UploaderConfiguration { get; } = new FolderAlbumUploaderConfiguration();
}