using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using System;

namespace Calabonga.AlbumsManager.Builders
{
    /// <summary>
    /// Default viewer builder as the third step for <see cref="AlbumManager{TItem}"/> processing configuration.
    /// </summary>
    internal sealed class ViewerBuilder<TItem> : IViewerBuilder<TItem>
        where TItem : ItemBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAlbumBuilder<TItem> _albumBuilder;

        public ViewerBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
        {
            _configuration = configuration;
            _albumBuilder = albumBuilder;
        }

        /// <summary>
        /// Append a viewer processing configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public IMetadataBuilder<TItem> AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration)
            where TViewerConfiguration : IViewerConfiguration
        {
            configuration((TViewerConfiguration)_configuration.ViewerConfiguration);
            return new MetadataBuilder<TItem>(_configuration, _albumBuilder);
        }
    }
}