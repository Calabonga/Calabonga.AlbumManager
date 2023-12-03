using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerViewerBuilder)
/// </summary>
internal sealed class ViewerBuilder<TItem> : IViewerBuilder<TItem>
    where TItem : class
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public ViewerBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public IMetadataBuilder<TItem> AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration)
    {
        configuration((TViewerConfiguration)_configuration.ViewerConfiguration);
        return new MetadataBuilder<TItem>(_configuration, _albumBuilder);
    }
}