namespace IGE.Core.CoreSystems.Movement.Components;

using Microsoft.Xna.Framework;

using MonoGame.Extended;

public class Movable
{
  public Movable(Vector2 direction, float velocity)
  {
    Direction = direction;
    Velocity = velocity;
  }

  public Vector2 Direction { get; set; }

  public float Velocity { get; set; }

  public Vector2 GetNormalizedDirection()
  {
    if (Direction == Vector2.Zero)
      return Vector2.Zero;

    return Direction.NormalizedCopy();
  }
}
