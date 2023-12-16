namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Metadata processing
/// </summary>
public interface IMetadataConfiguration
{
    IMetadataProcessor? MetadataProcessor { get; }

    public void SetMetadataProcessor(IMetadataProcessor metadataProcessor);
}