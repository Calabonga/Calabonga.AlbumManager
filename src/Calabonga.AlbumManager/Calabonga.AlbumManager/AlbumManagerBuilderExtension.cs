using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.CommandProcessors;
using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Folder.Creator;
using Calabonga.AlbumsManager.FolderTree.Creator;
using Calabonga.AlbumsManager.Models;

namespace Calabonga.AlbumsManager;

/// <summary>
/// Helper for <see cref="AlbumManager{TItem}"/> configuration with predefined parameters on processors.
/// </summary>
public static class AlbumManagerBuilder
{
    /// <summary>
    /// Returns an instance of the <see cref="AlbumManager{AlbumImage}"/> for one folder with many images.
    /// </summary>
    /// <param name="folder">The folder contains images.</param>
    /// <param name="pageIndex">The page index for pagination. If the <see cref="pageSize"/> is equals 0 then paging ignored. Default value is 0.</param> 
    /// <param name="pageSize">The number items in the page. When it is equals 0 then paging ignored. Default value is 0.</param>
    /// <returns>an instance of the <see cref="AlbumManager{TItem}"/></returns>
    public static async Task<AlbumManager<AlbumImage>> GetImagesFromFolderAsync(string folder, int pageIndex, int pageSize)
        => await new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
            .AddCreator<CreatorConfiguration>(x =>
            {
                x.PageIndex = pageIndex;
                x.PageSize = pageSize;
                x.SourcePath = folder;
            })
            .AddViewer<ViewerConfiguration>(x =>
            {
                //x.AddImageProcessor(new TextWatermarkImageProcessor());
            })
            .AddMetadataReader<MetadataConfiguration>(x =>
            {
                //x.SetMetadataProcessor(new TextMetadataProcessor());
            })
            .AddCommander<CommanderConfiguration>(x =>
            {
                x.SetCommandProcessor(new CommandProcessor(c =>
                {
                    c.AddCommand<GetImageByIdCommand, GetImageByIdCommandHandler>();
                    c.AddCommand<DeleteImageByIdCommand, DeleteImageByIdCommandHandler>();
                    c.AddCommand<UploadImageByIdCommand, UploadImageByIdCommandHandler>();
                }));
            })
            .AddUploader<UploaderConfiguration>(_ => { })
            .BuildAsync(CancellationToken.None);

    /// <summary>
    /// Returns an instance of the <see cref="AlbumManager{AlbumImage}"/> for one folder where many folders with images.
    /// </summary>
    /// <param name="folderTree">The folder contains images.</param>
    /// <param name="pageIndex">The page index for pagination. If the <see cref="pageSize"/> is equals 0 then paging ignored. Default value is 0.</param> 
    /// <param name="pageSize">The number items in the page. When it is equals 0 then paging ignored. Default value is 0.</param>
    /// <returns>an instance of the <see cref="AlbumManager{TItem}"/></returns>
    public static async Task<AlbumManager<AlbumDirectory>> GetDirectoriesFromFolderTreeAsync(string folderTree, int pageIndex, int pageSize)
        => await new AlbumManagerBuilder<FolderTreeAlbumBuilder, DefaultConfiguration, AlbumDirectory>()
            .AddCreator<CreatorConfiguration>(x =>
            {
                x.PageIndex = pageIndex;
                x.PageSize = pageSize;
                x.SourcePath = folderTree;
                x.SkipFoundImages = true;
            })
            .AddViewer<ViewerConfiguration>(x => { })
            .AddMetadataReader<MetadataConfiguration>(_ => { })
            .AddCommander<CommanderConfiguration>(_ => { })
            .AddUploader<UploaderConfiguration>(_ => { })
            .BuildAsync(CancellationToken.None);
}