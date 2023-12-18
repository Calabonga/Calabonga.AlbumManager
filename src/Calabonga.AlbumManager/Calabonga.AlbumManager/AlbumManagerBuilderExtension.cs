using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.CommandProcessors;
using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.FolderTree.Creator;
using Calabonga.AlbumsManager.ImageProcessors;
using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// // Calabonga: update summary (2023-12-03 08:10 AlbumManagerBuilderExtension)
/// </summary>
public static class AlbumManagerBuilder
{
    public static async Task<AlbumManager<AlbumImage>> GetImagesFromFolderAsync(string folder)
        => await new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
            .AddCreator<CreatorConfiguration>(x => x.SourcePath = folder)
            .AddViewer<ViewerConfiguration>(x =>
            {
                x.AddImageProcessor(new TextWatermarkImageProcessor());
            })
            .AddMetadataReader<MetadataConfiguration>(x =>
            {
                x.SetMetadataProcessor(new TextMetadataProcessor());
            })
            .AddCommander<CommanderConfiguration>(x =>
            {
                x.SetCommandProcessor(new CommandProcessor(c =>
                {
                    c.AddCommand<GetImageByIdCommand, GetImageByIdCommandHandler>();
                }));
            })
            .AddUploader<UploaderConfiguration>(_ => { })
            .BuildAsync(CancellationToken.None);

    public static async Task<AlbumManager<AlbumDirectory>> GetDirectoriesFromFolderTreeAsync(string folderTree)
        => await new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
            .AddCreator<CreatorConfiguration>(x =>
            {
                x.SourcePath = folderTree;
                x.SkipFoundImages = true;
            })
            .AddViewer<ViewerConfiguration>(x => { })
            .AddMetadataReader<MetadataConfiguration>(_ => { })
            .AddCommander<CommanderConfiguration>(_ => { })
            .AddUploader<UploaderConfiguration>(_ => { })
            .BuildAsync(CancellationToken.None);
}