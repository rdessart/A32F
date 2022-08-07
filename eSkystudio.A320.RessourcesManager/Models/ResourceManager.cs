using SFML.Graphics;

namespace eSkystudio.A320.RessourcesManager.Models;

public class ResourceManager
{
    public Dictionary<string, Color> Colors { get; set; }
    public Dictionary<string, Font> Fonts { get; set; }

    public ResourceManager()
    {
        Colors = new Dictionary<string, Color>();
        Fonts = new Dictionary<string, Font>();
    }

    public ResourceManager(ResourceLocator? rl) : this()
    {
        LoadFromLocator(rl);
    }

    public void LoadFromLocator(ResourceLocator? rl)
    {
        if (rl is null) return;
        foreach (var kv in rl.Colors)
        {
            string[] sub = kv.Value.Split(' ');
            Colors[kv.Key] = new Color(
                byte.Parse(sub[0], System.Globalization.NumberStyles.HexNumber),
                byte.Parse(sub[1], System.Globalization.NumberStyles.HexNumber),
                byte.Parse(sub[2], System.Globalization.NumberStyles.HexNumber),
                0xFF);
        }
        foreach (var kv in rl.Fonts)
        {
            Fonts[kv.Key] = new Font(kv.Value);
        }
    }
}