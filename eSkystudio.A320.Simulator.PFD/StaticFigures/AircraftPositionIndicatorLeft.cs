using SFML.Graphics;
using SFML.System;

namespace eSkystudio.A320.Simulator.PFD.StaticFigures;

public class AircraftPositionIndicatorLeft : Shape
{
    // private int _width;
    // private int _height;
    // private int _height2;

    // public int Width
    // {
    //     get => _width;
    //     set
    //     {
    //         _width = value;
    //         Generate();
    //     }
    // }
    //
    // public int Height2{
    //     get => _height2;
    //     set
    //     {
    //         _height2 = value;
    //         Generate();
    //     }
    // }
    // public int Height{
    //     get => _height;
    //     set
    //     {
    //         _height = value;
    //         Generate();
    //     }
    // }

    private int _x1;
    private int _x2;
    private int _y1;
    private int _y2;
    
    public int X1 { 
        get => _x1;
        set
        {
            _x1 = value;
            Generate();
        }
    }
    public int X2{ 
        get => _x2;
        set
        {
            _x2 = value;
            Generate();
        }
    }
    public int Y1{ 
        get => _y1;
        set
        {
            _y1 = value;
            Generate();
        }
    }
    public int Y2{ 
        get => _y2;
        set
        {
            _y2 = value;
            Generate();
        }
    }
    
    public AircraftPositionIndicatorLeft() : base()
    {
        _points = Array.Empty<Vector2f>();
        // Width = 100;
        // Height = 20;
        // Height2 = 50;
        X2 = 100;
        X1 = 80;
        Y1 = 20;
        Y2 = 50;
        Generate();
        Update();
    }
    public void Generate()
    {
        _points = new[]
        {
            new Vector2f(0.0f, 0.0f),
            new Vector2f(_x2, 0.0f),
            new Vector2f(_x2, _y2),
            new Vector2f(_x1, _y2),
            new Vector2f(_x1, _y1),
            new Vector2f(0.0f, _y1)
            // new(0.0f, Height),
            // new(Width, Height),
            // new(Width, 0.0f),
            // new(Width - Height, 0.0f),
            // new(Width - Height, Height2),
            // new(Width, Height2),
            // new(Width, 0.0f),
        };
    }

    private Vector2f[] _points;

    public override uint GetPointCount() => (uint)_points.Length;

    public override Vector2f GetPoint(uint index) => _points[index];
}