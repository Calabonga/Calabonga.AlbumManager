using Calabonga.AlbumsManager.Configurations;

namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// Global interface configuration
/// </summary>
public interface IConfiguration
{
    /// <summary>
    /// Configuration for Creator processing
    /// </summary>
    ICreatorConfiguration CreatorConfiguration { get; }

    /// <summary>
    /// Configuration for Viewer processing
    /// </summary>
    IViewerConfiguration ViewerConfiguration { get; }

    /// <summary>
    /// Configuration for Metadata processing
    /// </summary>
    IMetadataConfiguration MetadataConfiguration { get; }

    /// <summary>
    /// Configuration for Editor processing
    /// </summary>
    IEditorConfiguration EditorConfiguration { get; }

    /// <summary>
    /// Configuration for Uploader processing
    /// </summary>
    IUploaderConfiguration UploaderConfiguration { get; }
}

public abstract class Configuration : IConfiguration
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