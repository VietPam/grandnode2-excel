using Grand.Web.Common.Themes;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Theme.Minimal;

public class PluginViewLocationExpander: IViewLocationExpander
{
    private const string ThemeKey = "Plugin";

    public void PopulateValues(ViewLocationExpanderContext context)
    {
        context.Values[ThemeKey] = "Plugin";
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        if (context.Values.TryGetValue("Theme", out var theme) && theme == "Minimal")
        {
            viewLocations = new[] {
                    $"/Plugins/Theme.Minimal/Views/Minimal/{{1}}/{{0}}.cshtml",
                }
                .Concat(viewLocations);
        }

        return viewLocations;
    }
}