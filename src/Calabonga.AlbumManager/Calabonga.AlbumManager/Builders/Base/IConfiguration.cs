﻿namespace Calabonga.AlbumsManager.Builders.Base;

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