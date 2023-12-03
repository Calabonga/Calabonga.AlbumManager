using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.Models;

//builder.AddCreator<FolderTreeAlbumCreator, FolderTreeAlbumCreatorConfiguration>(x => x.SourceRootPath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");
//var manager1 = new AlbumManagerBuilder().AddDefaultFolder("C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");

var manager = new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
    .AddCreator<CreatorConfiguration>(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals")
    .AddViewer<ViewerConfiguration>(x => x.TakeTop = 10)
    .AddMetadataReader<MetadataConfiguration>(x => x.Enabled = false)
    .AddEditor<EditorConfiguration>(x => x.Enabled = false)
    .AddUploader<UploaderConfiguration>(x => x.Enabled = false)
    .Build();

//var manager = new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
//    .AddCreator(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery")
//    .AddViewer(x => x.TakeTop = 10)
//    .AddMetadataReader(x => x.Enabled = false)
//    .AddEditor(x => x.Enabled = false)
//    .AddUploader(x => x.Enabled = false)
//    .Build();

Console.WriteLine(manager.ToString());

var view = manager.GetView();

foreach (var item in view.Items)
{
    Console.WriteLine($"{item.FileName}- {((double)item.FileSize / 1024):F2} Kb");
}

//foreach (var item in view.Items)
//{
//    Console.WriteLine($"{item.DirectoryName} - {item.Items?.Count() ?? 0} items count");
//}
