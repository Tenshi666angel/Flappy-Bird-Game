using FlappyBird.GameObjects;
using SFML.System;

namespace FlappyBird;

public class Pipes
{
    private Pipe[] _pipes;
    private const float _speed = 3;
    private const float _spaceBetween = 100;
    private float _offset;

    public Pipe[] PipesArr { get => _pipes; private set => _pipes = value; }
    #pragma warning disable
    public Pipes()
    {
        PipesArr = new Pipe[8];

        _offset = new Random().Next(0, 100);

        for(int i = 0; i < _pipes.Length; i++)
        {
            if(i % 2 == 0) _offset = new Random().Next(0, 100);

            _pipes[i] = i % 2 == 0 
                ?
                new Pipe(new Vector2f(800 + (i + 1) * _spaceBetween, 270 + _offset))
                :
                new Pipe(new Vector2f(800 + (i) * _spaceBetween, -200 + _offset));
        }
    }

    public void Draw()
    {
        for(int i = 0; i < _pipes.Length; i++)
        {
            _pipes[i].Draw();
        }
    }

    public void Update()
    {
        for(int i = 0; i < _pipes.Length; i++)
        {
            _pipes[i].Move(-_speed, 0);

            _pipes[i].Update();

            if(_pipes[i].Position.X < -60)
            {
                float yPos = _pipes[i].Position.Y;

                _pipes[i].Position = new Vector2f(800, yPos);
            }
        }
    }
}
