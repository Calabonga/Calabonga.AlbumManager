using Calabonga.AlbumsManager;

var builder = new AlbumManagerBuilder();

builder.AddCreator(x => x.SourcePath = "C:\\Projects\\Calabonga.AlbumManager\\whatnot\\Animals");

var manager = builder.Build();

Console.WriteLine(manager.ToString());

var view = manager.GetView();

foreach (var item in view.Items)
{
    Console.WriteLine($"{item.FileSize} - {item.FileName}");
}
