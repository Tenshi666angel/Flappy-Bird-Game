using SFML.Graphics;
using SFML.Window;

namespace FlappyBird.Utils;

public class GameConstants
{
    private static readonly object _lock = new();
    
    private static GameConstants? _instanse = null;

    public RenderWindow? Window { get; private set; } = new RenderWindow(new VideoMode(800, 400), "Flappy bird");
    
    public static GameConstants Instanse
    {
        get
        {
            lock(_lock)
            {
                _instanse ??= new GameConstants();

                return _instanse;
            }
        }
    }
}