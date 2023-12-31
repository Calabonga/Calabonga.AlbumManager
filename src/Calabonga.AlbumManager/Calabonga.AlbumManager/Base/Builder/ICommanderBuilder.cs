﻿using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Base.Builder;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
public interface ICommanderBuilder<TItem> where TItem : ItemBase
{
    /// <summary>
    /// // Calabonga: update summary (2023-11-18 02:19 IAlbumManagerEditorBuilder)
    /// </summary>
    /// <param name="configuration"></param>
    IUploaderBuilder<TItem> AddCommander<TEditorConfiguration>(Action<TEditorConfiguration> configuration);
}