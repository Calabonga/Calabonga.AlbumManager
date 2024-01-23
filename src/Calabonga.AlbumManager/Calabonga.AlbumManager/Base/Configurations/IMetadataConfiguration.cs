namespace Calabonga.AlbumsManager.Base.Configurations;

/// <summary>
/// Configuration for Metadata processing
/// </summary>
public interface IMetadataConfiguration
{
    /// <summary>
    /// Instance of the <see cref="IMetadataProcessor"/>
    /// </summary>
    IMetadataProcessor? MetadataProcessor { get; }

    /// <summary>
    /// Setups <see cref="IMetadataProcessor"/> for current AlbumManagedBuilder.
    /// </summary>
    /// <param name="metadataProcessor"></param>
    public void SetMetadataProcessor(IMetadataProcessor metadataProcessor);
}