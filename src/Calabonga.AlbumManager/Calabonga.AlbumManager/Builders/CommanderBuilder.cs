using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using System;

namespace Calabonga.AlbumsManager.Builders
{
    /// <summary>
    /// Default implementation of command builder (CommandProcessor), that can processing some commands registered in pipeline.
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    internal sealed class CommanderBuilder<TItem> : ICommanderBuilder<TItem>
        where TItem : ItemBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAlbumBuilder<TItem> _albumBuilder;

        public CommanderBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
        {
            _configuration = configuration;
            _albumBuilder = albumBuilder;
        }

        /// <summary>
        /// Adds a command processor to  pipeline.
        /// </summary>
        /// <param name="configuration">configuration to add</param>
        public IUploaderBuilder<TItem> AddCommander<TCommanderConfiguration>(Action<TCommanderConfiguration> configuration)
            where TCommanderConfiguration : ICommanderConfiguration
        {
            configuration((TCommanderConfiguration)_configuration.CommanderConfiguration);
            return new UploaderBuilder<TItem>(_configuration, _albumBuilder);
        }
    }
}