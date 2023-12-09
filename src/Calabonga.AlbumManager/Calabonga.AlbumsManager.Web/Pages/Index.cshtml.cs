using Calabonga.AlbumsManager.Builders;
using Calabonga.AlbumsManager.Configurations;
using Calabonga.AlbumsManager.Models;
using Calabonga.AlbumsManager.Web.Application;
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

    public void OnGet()
    {
        var folder = Path.Combine(_environment.WebRootPath, "Images");
        _logger.LogInformation(folder);
        Manager = new AlbumManagerBuilder<CustomAlbumBuilder, CustomConfiguration, AlbumDirectory>()
            .AddCreator<CustomCreatorConfiguration>(x =>
            {
                x.SourcePath = folder;
                x.SkipFoundImages = true;
            })
            .AddViewer<ViewerConfiguration>(x => x.TakeTop = 10)
            .AddMetadataReader<MetadataConfiguration>(x => x.Enabled = false)
            .AddEditor<EditorConfiguration>(x => x.Enabled = false)
            .AddUploader<UploaderConfiguration>(x => x.Enabled = false)
            .Build();

        var viewer = Manager.GetView();

        Directories = viewer.Items;
    }

    public IEnumerable<AlbumDirectory>? Directories { get; set; }
}