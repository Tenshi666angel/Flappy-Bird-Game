using FlappyBird.GameObjects;
using FlappyBird.Utils;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace FlappyBird;

public class MainWindow
{
    private readonly RenderWindow _window;
    private readonly Bird _bird;
    private readonly Background _background;
    private readonly Pipes _pipes;
    private bool isGameOver = false;
    private Font _font;
    private Text _gameOverText;
    private int _score = 0;
    private Text _scoreText;
    
    #pragma warning disable
    public MainWindow()
    {
        _window = GameConstants.Instanse.Window;
        _window.KeyPressed += OnKeyPressed;
        _window.Closed += OnWindowClose;

        _window.SetFramerateLimit(60);

        _bird = new Bird();
        _background = new Background();
        _pipes = new Pipes();

        _font = new Font("assets/CascadiaCode.ttf");

        _gameOverText = new Text();
        _gameOverText.Font = _font;
        _gameOverText.CharacterSize = 24;
        _gameOverText.Position = new Vector2f(_window.Size.X / 2 - 50, _window.Size.Y / 2 - 20);

        _scoreText = new Text();
        _scoreText.Font = _font;
        _scoreText.DisplayedString = _score.ToString();
        _scoreText.CharacterSize = 24;
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear(Color.Black);

            _background.Draw();
            _background.Update();

            if (!isGameOver)
            {
                _pipes.Draw();
                _bird.Draw();

                _bird.Update();
                _pipes.Update();

                _window.Draw(_scoreText);
            }
            else
            {
                _gameOverText.DisplayedString = $"Game over\nScore: {_score}";
                _window.Draw(_gameOverText);
                _window.KeyPressed -= _bird.OnBirdKeyPressed;
                _window.MouseButtonPressed -= _bird.OnBirdMousePressed;
            }

            if(CheckOut())
            {
                _score++;
                _scoreText.DisplayedString = _score.ToString();
            }

            if (CheckCollision()) isGameOver = true;

            if(_bird.Position.Y + _bird.Sprite.GetGlobalBounds().Height > _window.Size.Y) isGameOver = true;

            _window.Display();
        }
    }

    private bool CheckOut()
    {
        for(int i = 0; i < _pipes.PipesArr.Length; i++)
        {
            if (_bird.Position.X > _pipes.PipesArr[i].Position.X &&
                _bird.Position.X < _pipes.PipesArr[i].Position.X + 4)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckCollision()
    {
        for (int i = 0; i < _pipes.PipesArr.Length; i++)
        {
            if (_bird.Sprite.GetGlobalBounds().Intersects(_pipes.PipesArr[i].Sprite.GetGlobalBounds()))
            {
                return true;
            }
        }

        return false;
    }

    private void OnKeyPressed(object sender, KeyEventArgs e)
    {
        var window = (Window)sender;

        if (e.Code == Keyboard.Key.Escape)
        {
            window.Close();
        }
    }

    private void OnWindowClose(object sender, EventArgs e)
    {
        var window = (Window)sender;

        window.Close();
    }
}