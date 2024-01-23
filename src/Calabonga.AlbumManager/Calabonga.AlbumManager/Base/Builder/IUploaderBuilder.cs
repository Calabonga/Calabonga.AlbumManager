using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// Interface for Uploads configuration settings
/// </summary>
/// <typeparam name="TItem"></typeparam>
public interface IUploaderBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// Adds <see cref="IUploaderConfiguration"/> to processor pipeline.
    /// </summary>
    /// <param name="configuration">configuration to apply</param>
    IFinalBuilder<TItem> AddUploader<TUploaderConfiguration>(Action<TUploaderConfiguration> configuration)
        where TUploaderConfiguration : IUploaderConfiguration;
}