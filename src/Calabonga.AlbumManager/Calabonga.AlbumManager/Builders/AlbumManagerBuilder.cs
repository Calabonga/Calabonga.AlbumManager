﻿using Calabonga.AlbumsManager.Base.Builder;
using Calabonga.AlbumsManager.Base.Configurations;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager.Builders;

/// <summary>
/// Configuration builder for <see cref="AlbumManager&lt;TItem&gt;"/>
/// </summary>
public sealed class AlbumManagerBuilder<TCreator, TConfiguration, TItem>
    where TCreator : IAlbumBuilder<TItem>
    where TConfiguration : IConfiguration, new()
    where TItem : ItemBase
{
    private IAlbumBuilder<TItem> _albumBuilder = null!;

    public IViewerBuilder<TItem> AddCreator<TCreatorConfiguration>(Action<TCreatorConfiguration> configuration)
        where TCreatorConfiguration : ICreatorConfiguration
    {
        var config = new TConfiguration();
        configuration((TCreatorConfiguration)config.CreatorConfiguration);
        _albumBuilder = (TCreator)Activator.CreateInstance(typeof(TCreator), config)!;

        return new ViewerBuilder<TItem>(config, _albumBuilder);
    }
}