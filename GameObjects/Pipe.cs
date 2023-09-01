using FlappyBird.Utils;
using SFML.Graphics;
using SFML.System;

namespace FlappyBird.GameObjects;

public class Pipe : IGameObject
{
    #pragma warning disable
    private Vector2f _position;
    private Sprite _sprite;

    public Vector2f Position { get => _position; set => _position = value; }

    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public Pipe(Vector2f position)
    {
        _position = position;

        _sprite = new Sprite();
        _sprite.Texture = new Texture("assets/wall.png");
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