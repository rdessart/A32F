using System.Text.Json;
using eSkystudio.A320.RessourcesManager.Models;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

ResourceManager rm;

void DrawAHI(double pitch, double roll, RenderTarget target)
{
    target.Clear(Color.Transparent);

    Vertex[] ReferenceIndicatorL = new Vertex[] {
        new Vertex(new Vector2f(0.0f, 10.0f), Color.Yellow),
        new Vertex(new Vector2f(0.0f, 0.0f), Color.Yellow),
        new Vertex(new Vector2f(50.0f, 0.0f), Color.Yellow),
        new Vertex(new Vector2f(50.0f, 30.0f), Color.Yellow),
        new Vertex(new Vector2f(40.0f, 30.0f), Color.Yellow),
        new Vertex(new Vector2f(40.0f, 10.0f), Color.Yellow),
        new Vertex(new Vector2f(0.0f, 10.0f), Color.Yellow)
    };

    VertexBuffer b = new VertexBuffer((uint)ReferenceIndicatorL.Length, PrimitiveType.LineStrip, VertexBuffer.UsageSpecifier.Static)
    b.Update(ReferenceIndicatorL);
    

    RectangleShape sky = new(new Vector2f(400.0f, 400.0f))
    {
        FillColor = rm.Colors["Sky"],
        Position = new Vector2f(0.0f, 0.0f),
    };
    RectangleShape ground = new(new Vector2f(400.0f, 400.0f))
    {
        FillColor = rm.Colors["Ground"],
        Position = new Vector2f(0.0f, 400.0f),
    };
    target.Draw(sky);
    target.Draw(ground);
    target.Draw(b, RenderStates.Default);
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
    win.Clear(rm.Colors["Black"]);
    DrawAHI(0.0f, 0.0f, win);
    win.Display();
}

win.Close();

return 0x00;