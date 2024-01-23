using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using System;

namespace Calabonga.AlbumsManager.Base.Builder
{
    /// <summary>
    /// Interface abstraction for third step for <see cref="AlbumManager{TItem}"/> processing configuration.
    /// </summary>
    public interface IViewerBuilder<TItem>
        where TItem : ItemBase
    {
        /// <summary>
        /// Append a viewer processing configuration.
        /// </summary>
        /// <param name="configuration"></param>
        IMetadataBuilder<TItem> AddViewer<TViewerConfiguration>(Action<TViewerConfiguration> configuration)
            where TViewerConfiguration : IViewerConfiguration;
    }
}