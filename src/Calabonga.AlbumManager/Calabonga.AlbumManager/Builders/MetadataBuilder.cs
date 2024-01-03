using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// Default implementation of the metadata builder. This is a second step for <see cref="AlbumManager{TItem}"/> processing configuration.
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

    /// <summary>
    /// Appends a metadata configuration to processing pipeline.
    /// </summary>
    /// <param name="configuration"></param>
    public ICommanderBuilder<TItem> AddMetadataReader<TMetadataConfiguration>(Action<TMetadataConfiguration> configuration)
        where TMetadataConfiguration : IMetadataConfiguration
    {
        configuration((TMetadataConfiguration)_configuration.MetadataConfiguration);
        return new CommanderBuilder<TItem>(_configuration, _albumBuilder);
    }


}