using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;
using System;

namespace Calabonga.AlbumsManager.Builders
{
    /// <summary>
    /// Uploader configuration builder
    /// </summary>
    internal sealed class UploaderBuilder<TItem> : IUploaderBuilder<TItem>
        where TItem : ItemBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAlbumBuilder<TItem> _albumBuilder;

        public UploaderBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
        {
            _configuration = configuration;
            _albumBuilder = albumBuilder;
        }

        /// <summary>
        /// Adds <see cref="IUploaderConfiguration"/> to processor pipeline.
        /// </summary>
        /// <param name="configuration">configuration to apply</param>
        public IFinalBuilder<TItem> AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration)
            where TUploaderConfiguration : IUploaderConfiguration
        {
            configuration((TUploaderConfiguration)_configuration.UploaderConfiguration);
            return new FinalBuilder<TItem>(_configuration, _albumBuilder);
        }
    }
}