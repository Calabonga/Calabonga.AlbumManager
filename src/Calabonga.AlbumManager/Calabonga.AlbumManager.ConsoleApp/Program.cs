using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Folder.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;

//builder.AddCreator<FolderTreeAlbumCreator, FolderTreeAlbumCreatorConfiguration>(x => x.SourceRootPath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");
//var manager1 = new AlbumManagerBuilder().AddDefaultFolder("C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");

var manager = new AlbumManagerBuilder<FolderAlbumManagerCreator, FolderAlbumConfiguration>()
    .AddCreator(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals")
    .AddViewer(x => x.TakeTop = 10)
    .AddMetadataReader(x => x.Enabled = false)
    .AddEditor(x => x.Enabled = false)
    .AddUploader(x => x.Enabled = false)
    .Build();

Console.WriteLine(manager.ToString());

var view = manager.GetView();

foreach (var item in view.Items)
{
    Console.WriteLine($"{item.FileSize} - {item.FileName}");
}