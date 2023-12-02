using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.FolderTree.Creator;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

public static class AlbumManagerBuilder
{
    public static AlbumManager<AlbumItem> GetImagesFromFolder(string folder)
        => new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumItem>()
            .AddCreator<CreatorConfiguration>(x => x.SourcePath = folder)
            .AddViewer(x => x.TakeTop = 10)
            .AddMetadataReader(x => x.Enabled = false)
            .AddEditor(x => x.Enabled = false)
            .AddUploader(x => x.Enabled = false)
            .Build();

    public static AlbumManager<AlbumDirectory> GetImagesFromFolderTree(string folderTree)
        => new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
            .AddCreator<CreatorConfiguration>(x => x.SourcePath = folderTree)
            .AddViewer(x => x.TakeTop = 10)
            .AddMetadataReader(x => x.Enabled = false)
            .AddEditor(x => x.Enabled = false)
            .AddUploader(x => x.Enabled = false)
            .Build();
}