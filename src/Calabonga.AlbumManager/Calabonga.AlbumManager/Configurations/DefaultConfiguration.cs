using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Global interface configuration for Folder Album
/// </summary>
public class DefaultConfiguration : IConfiguration
{
    /// <summary>
    /// Configuration for Creator processing
    /// </summary>
    public ICreatorConfiguration CreatorConfiguration { get; } = new CreatorConfiguration();

    /// <summary>
    /// Configuration for Viewer processing
    /// </summary>
    public IViewerConfiguration ViewerConfiguration { get; } = new ViewerConfiguration();

    /// <summary>
    /// Configuration for Metadata processing
    /// </summary>
    public IMetadataConfiguration MetadataConfiguration { get; } = new MetadataConfiguration();

    /// <summary>
    /// Configuration for Editor processing
    /// </summary>
    public IEditorConfiguration EditorConfiguration { get; } = new EditorConfiguration();

    /// <summary>
    /// Configuration for Uploader processing
    /// </summary>
    public IUploaderConfiguration UploaderConfiguration { get; } = new UploaderConfiguration();
}