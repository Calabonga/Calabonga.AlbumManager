using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.FolderTree.Creator;
using Calabonga.AlbumsManager.ImageProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// // Calabonga: update summary (2023-12-03 08:10 AlbumManagerBuilderExtension)
/// </summary>
public static class AlbumManagerBuilder
{
    public static AlbumManager<AlbumImage> GetImagesFromFolder(string folder)
        => new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
            .AddCreator<CreatorConfiguration>(x => x.SourcePath = folder)
            .AddViewer<ViewerConfiguration>(x =>
            {
                x.AddImageProcessor(new WatermarkImageProcessor());
            })
            .AddMetadataReader<MetadataConfiguration>(x => x.Enabled = false)
            .AddEditor<EditorConfiguration>(x => x.Enabled = false)
            .AddUploader<UploaderConfiguration>(x => x.Enabled = false)
            .Build();

    public static AlbumManager<AlbumDirectory> GetDirectoriesFromFolderTree(string folderTree)
        => new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
            .AddCreator<CreatorConfiguration>(x =>
            {
                x.SourcePath = folderTree;
                x.SkipFoundImages = true;
            })
            .AddViewer<ViewerConfiguration>(x => { })
            .AddMetadataReader<MetadataConfiguration>(x => x.Enabled = false)
            .AddEditor<EditorConfiguration>(x => x.Enabled = false)
            .AddUploader<UploaderConfiguration>(x => x.Enabled = false)
            .Build();
}