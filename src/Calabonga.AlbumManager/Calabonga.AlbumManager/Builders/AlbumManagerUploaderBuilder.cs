using Calabonga.AlbumsManager.Builders.Base;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
/// </summary>
internal sealed class UploaderBuilder<TItem> : IUploaderBuilder<TItem>
    where TItem : class
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public UploaderBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public IFinalBuilder<TItem> AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration)
    {
        configuration((TUploaderConfiguration)_configuration.UploaderConfiguration);
        return new FinalBuilder<TItem>(_configuration, _albumBuilder);
    }
}