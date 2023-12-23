namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Viewer processing
/// </summary>
public interface IViewerConfiguration
{
    /// <summary>
    /// Returns processors for images only
    /// </summary>
    IEnumerable<IImageProcessor> ImageProcessors { get; }

    void AddImageProcessor(IImageProcessor processor);
}