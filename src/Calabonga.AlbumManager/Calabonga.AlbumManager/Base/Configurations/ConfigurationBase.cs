using Calabonga.AlbumsManager.Configurations;

namespace Calabonga.AlbumsManager.Base.Configurations
{
    /// <summary>
    /// Default abstract configuration for <see cref="AlbumManager{TItem}"/> processing pipelines.
    /// </summary>
    public abstract class ConfigurationBase : IConfiguration
    {
        /// <summary>
        /// Configuration for Creator processing
        /// </summary>
        public virtual ICreatorConfiguration CreatorConfiguration { get; } = new CreatorConfiguration();

        /// <summary>
        /// Configuration for Viewer processing
        /// </summary>
        public virtual IViewerConfiguration ViewerConfiguration { get; } = new ViewerConfiguration();

        /// <summary>
        /// Configuration for Metadata processing
        /// </summary>
        public virtual IMetadataConfiguration MetadataConfiguration { get; } = new MetadataConfiguration();

        /// <summary>
        /// Configuration for Editor processing
        /// </summary>
        public virtual ICommanderConfiguration CommanderConfiguration { get; } = new CommanderConfiguration();

        /// <summary>
        /// Configuration for Uploader processing
        /// </summary>
        public IUploaderConfiguration UploaderConfiguration { get; } = new UploaderConfiguration();
    }
}