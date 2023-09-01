using FlappyBird.GameObjects;
using SFML.System;

namespace FlappyBird;

public class Background
{
    private readonly BackgroundUnit[] _backs = new BackgroundUnit[2];
    private const float _speed = 3;

    public Background()
    {
        _backs[0] = new BackgroundUnit(0, 0);
        _backs[1] = new BackgroundUnit(800, 0);
    }

    public void Draw()
    {
        for(int i = 0; i < _backs.Length; i++)
        {
            _backs[i].Draw();
        }
    }

    public void Update()
    {
        for(int i = 0; i < _backs.Length; i++)
        {
            _backs[i].Move(-_speed, 0);
            _backs[i].Update();
        }

        if(_backs[0].Position.X < -800)
        {
            _backs[0].Position = new Vector2f(0, 0);
            _backs[1].Position = new Vector2f(800, 0);
        }
    }
}