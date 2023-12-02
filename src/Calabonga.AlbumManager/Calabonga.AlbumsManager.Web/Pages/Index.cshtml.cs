using Calabonga.AlbumsManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calabonga.AlbumsManager.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IWebHostEnvironment environment,
        ILogger<IndexModel> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public void OnGet()
    {
        var folder = Path.Combine(_environment.WebRootPath, "Images");
        _logger.LogInformation(folder);
        var manager = AlbumManagerBuilder.GetImagesFromFolderTree(folder);
        var viewer = manager.GetView();

        Directories = viewer.Items;
    }

    public IEnumerable<AlbumDirectory>? Directories { get; set; }
}