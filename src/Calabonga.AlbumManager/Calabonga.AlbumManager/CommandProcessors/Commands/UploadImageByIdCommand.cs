using Calabonga.AlbumsManager.Base;

namespace Calabonga.AlbumsManager.CommandProcessors.Commands;

/// <summary>
/// Upload file to current <see cref="AlbumManager{TItem}"/> configured folder.
/// </summary>
/// <param name="Bytes"></param>
/// <param name="FileName"></param>
public record UploadImageByIdCommand(byte[] Bytes, string FileName)
    : ICommand<UploadResult>;