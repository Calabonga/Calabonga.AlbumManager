using Calabonga.AlbumsManager.CommandProcessors.Commands;
using Calabonga.AlbumsManager.Models;
using Calabonga.PagedListCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Calabonga.AlbumsManager.Web.Pages;

public class DetailsModel : PageModel
{
    private readonly IMemoryCache _memory;
    private readonly IWebHostEnvironment _environment;

    public DetailsModel(
        IMemoryCache memory,
        IWebHostEnvironment environment)
    {
        _memory = memory;
        _environment = environment;
    }

    [BindProperty(SupportsGet = true)] public int PageIndex { get; set; }

    [BindProperty(SupportsGet = true)] public string? FolderName { get; set; }

    [BindProperty(SupportsGet = true)] public int PageSize { get; set; }

    public IEnumerable<string>? Commands { get; set; }

    public AlbumImage? SelectedImage { get; set; }

    public async Task<IActionResult> OnGet()
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }

        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(folder, PageIndex, 3);
        Commands = manager.Commands;
        PagedList = manager.PagedList;
        PageSize = manager.Configuration.CreatorConfiguration.PageSize;

        return Page();
    }

    public IPagedList<AlbumImage>? PagedList { get; set; }

    public async Task<IActionResult> OnGetImageById(string fileName)
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }

        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(folder, PageIndex, PageSize);
        Commands = manager.Commands;
        PagedList = manager.PagedList;

        SelectedImage = await manager.ExecuteAsync<AlbumImage, GetImageByIdCommand>(
            new GetImageByIdCommand(fileName),
            HttpContext.RequestAborted);

        return Page();
    }

    public async Task<IActionResult> OnGetDeleteImageById(string fileName)
    {
        if (string.IsNullOrWhiteSpace(FolderName))
        {
            return RedirectToPage("Error");
        }

        var folder = Path.Combine(_environment.WebRootPath, "Images", FolderName);
        var manager = await AlbumManagerBuilder.GetImagesFromFolderAsync(folder, PageIndex, PageSize);
        Commands = manager.Commands;
        PagedList = manager.PagedList;

        var isDeleteSuccess = await manager.ExecuteAsync<bool, DeleteImageByIdCommand>(
            new DeleteImageByIdCommand(fileName),
            HttpContext.RequestAborted);

        if (isDeleteSuccess)
        {
            SelectedImage = null;
        }

        return Page();
    }
}