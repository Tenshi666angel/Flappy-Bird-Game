using SFML.Graphics;
using SFML.System;

namespace FlappyBird.GameObjects;

public interface IGameObject
{
    Vector2f Position { get; }
    Sprite Sprite { get; }

    void Update();

    void Draw();
}
