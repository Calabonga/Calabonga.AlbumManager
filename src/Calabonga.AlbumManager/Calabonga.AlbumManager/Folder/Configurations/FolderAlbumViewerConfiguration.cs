using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Folder.Configurations;

/// <summary>
/// Configuration for Viewer processing in Folder mode
/// </summary>
public class FolderAlbumViewerConfiguration : IViewerConfiguration
{
    /// <summary>
    /// How many items should be taken when view created
    /// </summary>
    public int TakeTop { get; set; }
}