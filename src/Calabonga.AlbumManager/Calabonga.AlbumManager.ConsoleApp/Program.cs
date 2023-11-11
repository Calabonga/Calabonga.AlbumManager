using Calabonga.AlbumsManager;
using Calabonga.AlbumsManager.Creators.Folder;
//builder.AddCreator<FolderTreeAlbumCreator, FolderTreeAlbumCreatorConfiguration>(x => x.SourceRootPath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Gallery");

var builder = new AlbumManagerBuilder()
    .AddCreator<FolderAlbumCreator, FolderAlbumCreatorConfiguration>(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals")
    .AddViewer<FolderAlbumViewerConfiguration>(x => x.TakeTop = 10)
    .AddMetadataReader<FolderAlbumMetadataReaderConfiguration>(x => x.Enabled = false)
    .AddEditor<FolderAlbumEditorConfiguration>(x => x.Enabled = false)
    .AddUploader<FolderAlbumUploaderConfiguration>(x => x.Enabled = false);

var manager = builder.Build();

Console.WriteLine(manager.ToString());

var view = manager.GetView();

foreach (var item in view.Items)
{
    Console.WriteLine($"{item.FileSize} - {item.FileName}");
}

public class FolderAlbumViewerConfiguration
{
    public int TakeTop { get; set; }
}

public class FolderAlbumMetadataReaderConfiguration
{
    public bool Enabled { get; set; }
}

public class FolderAlbumEditorConfiguration
{
    public bool Enabled { get; set; }
}

public class FolderAlbumUploaderConfiguration
{
    public bool Enabled { get; set; }
}
