using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations;

/// <summary>
/// Configuration for Metadata processing in Folder mode
/// </summary>
public class MetadataConfiguration : IMetadataConfiguration
{
    public IMetadataProcessor? MetadataProcessor { get; private set; }

    public void SetMetadataProcessor(IMetadataProcessor metadataProcessor)
        => MetadataProcessor = metadataProcessor;
}