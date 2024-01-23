using Calabonga.AlbumsManager.Base;
using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.CommandProcessors;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Creators;
using Calabonga.AlbumsManager.ImageProcessors;
using Calabonga.AlbumsManager.MetadataProcessors;
using Calabonga.AlbumsManager.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Calabonga.AlbumsManager
{
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
        /// <param name="commandProcessor"></param>
        /// <param name="watermarkText"></param>
        /// <returns>an instance of the <see cref="AlbumManager{TItem}"/></returns>
        public static async Task<AlbumManager<AlbumImage>> GetImagesFromFolderAsync(
            string folder,
            int pageIndex,
            int pageSize,
            Action<ICommandProcessor>? commandProcessor = null,
            string? watermarkText = null)
            => await new AlbumManagerBuilder<FolderAlbumBuilder, DefaultConfiguration, AlbumImage>()
                .AddCreator<CreatorConfiguration>(x =>
                {
                    x.PageIndex = pageIndex;
                    x.PageSize = pageSize;
                    x.SourcePath = folder;
                })
                .AddViewer<ViewerConfiguration>(x =>
                {
                    if (!string.IsNullOrEmpty(watermarkText))
                    {
                        x.AddImageProcessor(new TextWatermarkImageProcessor(watermarkText));
                    }
                })
                .AddMetadataReader<MetadataConfiguration>(x =>
                {
                    x.SetMetadataProcessor(new TextMetadataProcessor());
                })
                .AddCommander<CommanderConfiguration>(x =>
                {
                    if (commandProcessor != null)
                    {
                        x.SetCommandProcessor(new CommandProcessor(commandProcessor));
                    }
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
}