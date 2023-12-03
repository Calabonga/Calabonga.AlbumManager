using Calabonga.AlbumsManager.Configurations;

namespace Calabonga.AlbumsManager.Builders.Base;
/// <summary>
/// // Calabonga: update summary (2023-12-03 08:03 Configuration)
/// </summary>
public abstract class ConfigurationBase : IConfiguration
{
    /// <summary>
    /// Configuration for Creator processing
    /// </summary>
    public virtual ICreatorConfiguration CreatorConfiguration { get; } = new CreatorConfiguration();

    /// <summary>
    /// Configuration for Viewer processing
    /// </summary>
    public virtual IViewerConfiguration ViewerConfiguration { get; } = new ViewerConfiguration();

    /// <summary>
    /// Configuration for Metadata processing
    /// </summary>
    public virtual IMetadataConfiguration MetadataConfiguration { get; } = new MetadataConfiguration();

    /// <summary>
    /// Configuration for Editor processing
    /// </summary>
    public virtual IEditorConfiguration EditorConfiguration { get; } = new EditorConfiguration();

    /// <summary>
    /// Configuration for Uploader processing
    /// </summary>
    public IUploaderConfiguration UploaderConfiguration { get; } = new UploaderConfiguration();
}