﻿namespace Calabonga.AlbumsManager.Builders.Base;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:16 AlbumManagerUploaderBuilder)
/// </summary>
public interface IAlbumManagerUploaderBuilder
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-11 12:17 AlbumManagerUploaderBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IFinalBuilder AddUploader(Action<IUploaderConfiguration> configuration);
}