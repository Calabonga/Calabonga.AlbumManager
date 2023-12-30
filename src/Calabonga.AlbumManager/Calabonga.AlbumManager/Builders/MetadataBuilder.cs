using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerMetadataBuilder)
/// </summary>
internal sealed class MetadataBuilder<TItem> : IMetadataBuilder<TItem>
    where TItem : ItemBase
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public MetadataBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public ICommanderBuilder<TItem> AddMetadataReader<TMetadataConfiguration>(Action<TMetadataConfiguration> configuration)
    {
        configuration((TMetadataConfiguration)_configuration.MetadataConfiguration);
        return new CommanderBuilder<TItem>(_configuration, _albumBuilder);
    }


}