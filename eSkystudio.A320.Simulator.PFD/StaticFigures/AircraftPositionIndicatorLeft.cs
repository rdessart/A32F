using SFML.Graphics;
using SFML.System;

namespace eSkystudio.A320.Simulator.PFD.StaticFigures;

public class AircraftPositionIndicatorLeft
{
    protected Vector2f _position;
    protected float _width;
    protected float _height;
    protected float _height2;
    protected float _outlineThickness;


    public AircraftPositionIndicatorLeft()
    {
        _position = new Vector2f(100.0f, 500.0f);
        _width = 100.0f;
        _height = 30.0f;
        _height2 = 50.0f;
        _outlineThickness = 2.0f;
    }
    
    public Vector2f Position
    {
        get => _position;
        set => _position = value;
    }

    public float Width
    {
        get => _width;
        set => _width = value;
    }
    
    public float Height
    {
        get => _height;
        set => _height = value;
    }
    
    public float Height2
    {
        get => _height2;
        set => _height2 = value;
    }
    
    public void Draw(RenderTarget target)
    {
        RectangleShape oRect0 = new RectangleShape()
        {
            Size = new Vector2f(_width + (2 * _outlineThickness), _height + (2 * _outlineThickness)),
            Position = new Vector2f(_position.X - _outlineThickness, 
                                    _position.Y - ((_height / 2.0f) + _outlineThickness)),
            FillColor = Color.Yellow,
        };
        
        RectangleShape oRect1 = new RectangleShape()
        {
            Size = new Vector2f(_height + (2 * _outlineThickness), _height2 + (2.0f * _outlineThickness)),
            Position = new Vector2f(_position.X + (_width - _height - _outlineThickness), 
                                    _position.Y - 2.0f),
            FillColor = Color.Yellow,
        };
        
        RectangleShape rect0 = new RectangleShape()
        {
            Size = new Vector2f(_width, _height),
            Position = new Vector2f(_position.X, _position.Y - 15.0f),
            FillColor = Color.Black,
        };
        
        RectangleShape rect1 = new RectangleShape()
        {
            Size = new Vector2f(_height, _height2),
            Position = new Vector2f(_position.X + (_width - _height), _position.Y),
            FillColor = Color.Black,
        };
        target.Draw(oRect0);
        target.Draw(oRect1);
        target.Draw(rect0);
        target.Draw(rect1);
    }
}