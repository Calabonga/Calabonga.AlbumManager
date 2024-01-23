using System.Collections.Generic;

namespace Calabonga.AlbumsManager.Base.Configurations
{
    /// <summary>
    /// Configuration for Viewer processing
    /// </summary>
    public interface IViewerConfiguration
    {
        /// <summary>
        /// Returns processors for images only
        /// </summary>
        IEnumerable<IImageProcessor> ImageProcessors { get; }

        /// <summary>
        /// Setups an instance of the <see cref="IImageProcessor"/> for current <see cref="AlbumManagerBuilder"/>.
        /// </summary>
        /// <param name="processor"></param>
        void AddImageProcessor(IImageProcessor processor);
    }
}