using System.Text.Json;
using eSkystudio.A320.RessourcesManager.Models;
using eSkystudio.A320.Simulator.PFD.StaticFigures;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

ResourceManager rm;

void DrawAHI(double pitch, double roll, RenderTarget target)
{

    var left = new AircraftPositionIndicatorLeft()
    {
        Position = new Vector2f(2.0f, 490.0f),
        FillColor = Color.Black,
        OutlineColor = Color.Yellow,
        OutlineThickness = 2,
    };

    RectangleShape sky = new(new Vector2f(800.0f, 500.0f))
    {
        FillColor = rm.Colors["Sky"],
        Position = new Vector2f(0.0f, 0.0f),
    };
    RectangleShape ground = new(new Vector2f(800.0f, 500.0f))
    {
        FillColor = rm.Colors["Ground"],
        Position = new Vector2f(0.0f, 500.0f),
    };
    target.Draw(sky);
    target.Draw(ground);
    target.Draw(left);
}

static bool LoadRessources(out ResourceManager rm)
{
    rm = new ResourceManager();
    string resourcesPath = @"resources/resources.json";
    if (!File.Exists(resourcesPath))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Unable to find resource file : {resourcesPath} !");
        Console.ForegroundColor = ConsoleColor.White;
        return false;
    }

    string text = File.ReadAllText(resourcesPath);
    rm = new ResourceManager(JsonSerializer.Deserialize<ResourceLocator>(text));
    return true;
}


if(!LoadRessources(out rm) || rm is null)
{
    return 0x01;
}

RenderWindow win = new(new (800, 1000),"A320-PFD");
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
    win.Clear(rm.Colors["Black"]);
    DrawAHI(0.0f, 0.0f, win);
    win.Display();
}

win.Close();

return 0x00;