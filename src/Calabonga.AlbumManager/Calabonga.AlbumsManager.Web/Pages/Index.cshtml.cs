﻿using Calabonga.AlbumsManager.Models;
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

    public AlbumManager<AlbumDirectory> Manager { get; protected set; }

    public async Task OnGet()
    {
        var folder = Path.Combine(_environment.WebRootPath, "Images");
        _logger.LogInformation(folder);
        Manager = await AlbumManagerBuilder.GetDirectoriesFromFolderTreeAsync(folder);

        Directories = Manager.Items;
    }

    public IEnumerable<AlbumDirectory>? Directories { get; set; }
}