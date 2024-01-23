using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Viewer processing in Folder mode
/// </summary>
public class ViewerConfiguration : IViewerConfiguration
{
    private readonly List<IImageProcessor> _processors = new();

    /// <summary>
    /// Returns processors for images only
    /// </summary>
    public IEnumerable<IImageProcessor> ImageProcessors => _processors;

    /// <summary>
    /// Setups an instance of the <see cref="IImageProcessor"/> for current <see cref="AlbumManagerBuilder"/>.
    /// </summary>
    /// <param name="processor"></param>
    public void AddImageProcessor(IImageProcessor processor) => _processors.Add(processor);
}