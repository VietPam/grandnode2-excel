using Grand.Infrastructure;
using Grand.Web.Common.Themes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Theme.Minimal;

public class StartupApplication : IStartupApplication
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IThemeView, MinimalThemeView>();
        
        services.Configure<RazorViewEngineOptions>(options =>
        {
            /*
            options.ViewLocationFormats.Clear();
            options.ViewLocationFormats.Add(@"C:\Projects\Grandnode\grandnode2\src\Web\Grand.Web\Plugins\Theme.Minimal\{1}\{0}.cshtml");
            options.ViewLocationFormats.Add(@"C:\Projects\Grandnode\grandnode2\src\Web\Grand.Web\Plugins\Theme.Minimal\");
            options.ViewLocationFormats.Add(@"/Plugins/Theme.Minimal/");
            options.ViewLocationFormats.Add(@"/Plugins/Theme.Minimal/Views/{1}/{0}.cshtml");
            options.ViewLocationFormats.Add(@"/Plugins/Theme.Minimal/Views/Minimal/{1}/{0}.cshtml");
        */
            options.ViewLocationExpanders.Add(new PluginViewLocationExpander());

        });
    }

    public int Priority => 2000;

    public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
    {
    }

    public bool BeforeConfigure => false;
}