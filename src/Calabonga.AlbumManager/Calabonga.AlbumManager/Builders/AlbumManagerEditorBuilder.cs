﻿using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// // Calabonga: update summary (2023-11-11 12:15 AlbumManagerEditorBuilder)
/// </summary>
internal sealed class EditorBuilder<TItem> : IEditorBuilder<TItem>
    where TItem : ItemBase
{
    private readonly IConfiguration _configuration;
    private readonly IAlbumBuilder<TItem> _albumBuilder;

    public EditorBuilder(IConfiguration configuration, IAlbumBuilder<TItem> albumBuilder)
    {
        _configuration = configuration;
        _albumBuilder = albumBuilder;
    }

    public IUploaderBuilder<TItem> AddEditor<TEditorConfiguration>(Action<TEditorConfiguration> configuration)
    {
        configuration((TEditorConfiguration)_configuration.EditorConfiguration);
        return new UploaderBuilder<TItem>(_configuration, _albumBuilder);
    }
}