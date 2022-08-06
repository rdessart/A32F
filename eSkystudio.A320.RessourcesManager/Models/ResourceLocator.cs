using SFML.Graphics;

namespace eSkystudio.A320.RessourcesManager.Models;

public class ResourceLocator
{
    public Dictionary<string, string> Colors { get; set; }
    public Dictionary<string, string> Fonts { get; set; }

    public ResourceLocator()
    {
        Colors = new();
        Fonts = new();
    }
}