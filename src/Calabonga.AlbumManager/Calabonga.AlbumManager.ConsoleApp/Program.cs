﻿using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.Models;

//builder.AddCreator<FolderTreeAlbumCreator, FolderTreeAlbumCreatorConfiguration>(x => x.SourceRootPath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");
//var manager1 = new AlbumManagerBuilder().AddDefaultFolder("C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");

var manager = await new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
    .AddCreator<CreatorConfiguration>(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals")
    .AddViewer<ViewerConfiguration>(_ => { })
    .AddMetadataReader<MetadataConfiguration>(_ => { })
    .AddEditor<EditorConfiguration>(_ => { })
    .AddUploader<UploaderConfiguration>(_ => { })
    .BuildAsync(CancellationToken.None);

//var manager = new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
//    .AddCreator(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery")
//    .AddViewer(x => x.TakeTop = 10)
//    .AddMetadataReader(_ => {})
//    .AddEditor(_ => {})
//    .AddUploader(_ => {})
//    .BuildAsync();

Console.WriteLine(manager.ToString());

var view = manager.Items;

//foreach (var item in view.Items)
//{
//    Console.WriteLine($"{item.FileName}- {((double)item.FileSize / 1024):F2} Kb");
//}

//foreach (var item in view.Items)
//{
//    Console.WriteLine($"{item.DirectoryName} - {item.Items?.Count() ?? 0} items count");
//}
