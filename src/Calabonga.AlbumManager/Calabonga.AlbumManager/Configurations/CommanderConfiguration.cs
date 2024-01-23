using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Base.Configurations;

namespace Calabonga.AlbumsManager.Configurations
{
    /// <summary>
    /// Configuration for Editor processing in Folder mode
    /// </summary>
    public class CommanderConfiguration : ICommanderConfiguration
    {
        /// <summary>
        /// Command processor instance
        /// </summary>
        public ICommandProcessor? CommandProcessor { get; private set; }

        /// <summary>
        /// Setups an instance of the <see cref="ICommandProcessor"/> for current <see cref="AlbumManager{TItem}"/>
        /// </summary>
        /// <param name="commandProcessor"></param>
        public void SetCommandProcessor(ICommandProcessor commandProcessor) => CommandProcessor = commandProcessor;
    }
}