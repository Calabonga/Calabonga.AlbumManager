namespace Calabonga.AlbumsManager.Models;

/// <summary>
/// Base class for items metadata representation
/// </summary>
public abstract class ItemBase
{
    /// <summary>
    /// File of folder name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Current item path
    /// </summary>
    public string Path { get; set; } = null!;

    /// <summary>
    /// Description for current item.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates that current item can be processed with image processing.
    /// </summary>
    public virtual bool CanBeProcessed => true;

    /// <summary>
    /// Indicates that current item is a folder and can contain an images.
    /// </summary>
    public virtual bool HasItems => false;
}