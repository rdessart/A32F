using System.Text.Json;
using eSkystudio.A320.RessourcesManager.Models;
using SFML.Graphics;
using SFML.Window;

string resourcesPath = @"resources/resources.json";
if (!File.Exists(resourcesPath))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Unable to find resource file : {resourcesPath} !");
    Console.ForegroundColor = ConsoleColor.White;
    return 0x01;
}

string text = File.ReadAllText(resourcesPath);
ResourceManager rm = new ResourceManager(JsonSerializer.Deserialize<ResourceLocator>(text) ?? 
                                         throw new NullReferenceException(""));

RenderWindow win = new(new (750, 1000),"A320-PFD");
win.SetFramerateLimit(20);
win.KeyPressed += (sender, ev) =>
{
    if (ev.Code == Keyboard.Key.Escape)
    {
        win.Close();
    }
};

while (win.IsOpen)
{
    win.DispatchEvents();
    win.Clear(rm.Colors["Sky"]);
    win.Display();
}

win.Close();

return 0x00;