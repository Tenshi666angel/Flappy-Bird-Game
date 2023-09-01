using FlappyBird.GameObjects;
using FlappyBird.Utils;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FlappyBird;

public class Bird : IGameObject
{
    #pragma warning disable
    private Vector2f _position;
    private Sprite _sprite;

    private const float _gravity = 0.7f;
    private float _dy = 0;

    public Vector2f Position { get => _position; }

    public Sprite Sprite { get => _sprite; }

    public Bird()
    {
        _position.X = 200;
        _position.Y = 120;
        
        _sprite = new Sprite();
        _sprite.Texture = new Texture("assets/bird.png");
        _sprite.Position = _position;

        GameConstants.Instanse.Window.KeyPressed += OnBirdKeyPressed;
        GameConstants.Instanse.Window.MouseButtonPressed += OnBirdMousePressed;
    }

    public void Draw()
    {
        GameConstants.Instanse.Window.Draw(_sprite);
    }

    public void Update()
    {
        _dy += _gravity;
        _position.Y += _dy;

        _sprite.Position = _position;
    }

    public void OnBirdKeyPressed(object sender, KeyEventArgs e)
    {
        if(e.Code == Keyboard.Key.Space)
        {
            _dy = -10;
        }
    }
    public void OnBirdMousePressed(object sender, MouseButtonEventArgs e)
    {
        if(e.Button == Mouse.Button.Left)
        {
            _dy = -10;
        }
    }
}