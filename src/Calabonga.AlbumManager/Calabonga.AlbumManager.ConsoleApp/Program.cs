using Calabonga.AlbumsManager;
using Calabonga.AlbumsManager.Creators.Folder;

var builder = new AlbumManagerBuilder();

builder.AddCreator<FolderAlbumCreator, FolderAlbumCreatorConfiguration>(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals");
// builder.AddCreator<FolderTreeAlbumCreator, FolderTreeAlbumCreatorConfiguration>(x => x.SourceRootPath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");

var manager = builder.Build();

Console.WriteLine(manager.ToString());

var view = manager.GetView();

foreach (var item in view.Items)
{
    Console.WriteLine($"{item.FileSize} - {item.FileName}");
}
