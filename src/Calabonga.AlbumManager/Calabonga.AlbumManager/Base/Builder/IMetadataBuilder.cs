using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Interface abstraction for second step for <see cref="AlbumManager{TItem}"/> processing configuration.
/// </summary>
public interface IMetadataBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// Appends a metadata configuration to processing pipeline.
    /// </summary>
    /// <param name="configuration"></param>
    ICommanderBuilder<TItem> AddMetadataReader<TMetadataConfiguration>(Action<TMetadataConfiguration> configuration)
        where TMetadataConfiguration : IMetadataConfiguration;
}