using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations
{
    /// <summary>
    /// Configuration for Metadata processing in Folder mode
    /// </summary>
    public class MetadataConfiguration : IMetadataConfiguration
    {
        /// <summary>
        /// Instance of the <see cref="IMetadataProcessor"/>
        /// </summary>
        public IMetadataProcessor? MetadataProcessor { get; private set; }

        /// <summary>
        /// Setups <see cref="IMetadataProcessor"/> for current AlbumManagedBuilder.
        /// </summary>
        /// <param name="metadataProcessor"></param>
        public void SetMetadataProcessor(IMetadataProcessor metadataProcessor)
            => MetadataProcessor = metadataProcessor;
    }
}