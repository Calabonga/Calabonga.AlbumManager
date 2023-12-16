using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.ImageProcessors;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Viewer processing in Folder mode
/// </summary>
public class ViewerConfiguration : IViewerConfiguration
{
    private readonly List<IImageProcessor> _processors = new();

    public IEnumerable<IImageProcessor> ImageProcessors => _processors;

    public void AddImageProcessor(IImageProcessor processor) => _processors.Add(processor);
}