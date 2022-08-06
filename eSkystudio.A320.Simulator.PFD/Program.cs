using SFML.Graphics;
using SFML.Window;

RenderWindow win = new(new (480, 640),"A320-PFD");
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
    win.Clear();
    win.Display();
}

win.Close();