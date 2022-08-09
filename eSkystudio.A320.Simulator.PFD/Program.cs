using System.Text.Json;
using eSkystudio.A320.RessourcesManager.Models;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

ResourceManager rm;

void DrawAHI(double pitch, double roll, RenderTarget target)
{
    target.Clear(Color.Transparent);

    int targetFillWidth = 100;
    int targetFillHeight = 20;
    int targetFillHeight2 = 50;

    VertexArray va = new VertexArray(PrimitiveType.Quads);

    va.Append(new Vertex(new(0.0f, 0.0f), Color.Black));
    va.Append(new Vertex(new(0.0f, targetFillHeight), Color.Black));
    va.Append(new Vertex(new(targetFillWidth, targetFillHeight), Color.Black));
    va.Append(new Vertex(new(targetFillWidth, 0.0f), Color.Black));
    va.Append(new Vertex(new(targetFillWidth - targetFillHeight, 0.0f), Color.Black));
    va.Append(new Vertex(new(targetFillWidth - targetFillHeight, targetFillHeight2), Color.Black));
    va.Append(new Vertex(new(targetFillWidth, targetFillHeight2), Color.Black));
    va.Append(new Vertex(new(targetFillWidth, targetFillHeight), Color.Black));



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
    target.Draw(va);
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