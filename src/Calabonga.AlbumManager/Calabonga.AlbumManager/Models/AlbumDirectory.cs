using System.Collections.Generic;
using System.Linq;

namespace Calabonga.AlbumsManager.Models
{
    /// <summary>
    /// Represents an image metadata for item that found in folder for <see cref="AlbumManager{TItem}"/>
    /// </summary>
    public class AlbumDirectory : ItemBase
    {
        /// <summary>
        /// Items in the folder
        /// </summary>
        public IEnumerable<AlbumImage>? Items { get; set; }

        /// <summary>
        /// Indicates that current item can be processed with image processing.
        /// </summary>
        public override bool CanBeProcessed => false;

        /// <summary>
        /// Indicates than current directory contain another directories.
        /// </summary>
        public override bool HasItems => Items != null && Items.Any();
    }
}