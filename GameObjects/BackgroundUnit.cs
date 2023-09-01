using FlappyBird.Utils;
using SFML.Graphics;
using SFML.System;

namespace FlappyBird.GameObjects;

public class BackgroundUnit : IGameObject
{
    #pragma warning disable
    private Vector2f _position;
    private Sprite? _sprite;

    public Vector2f Position { get => _position; set => _position = value; }

    public Sprite Sprite { get => _sprite; }

    public BackgroundUnit(float x, float y)
    {
        _position = new Vector2f(x, y);

        _sprite = new Sprite();
        _sprite.Texture = new Texture("assets/back.png");
        _sprite.Position = _position;
    }

    public void Draw()
    {
        GameConstants.Instanse.Window.Draw(_sprite);
    }

    public void Update()
    {
        _sprite.Position = _position;
    }

    public void Move(float x, float y)
    {
        _position.X += x;
        _position.Y += y;
    }
}
