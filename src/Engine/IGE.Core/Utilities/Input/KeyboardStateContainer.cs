namespace IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

public struct KeyStatus
{
  public bool IsDown { get; private set; }
  public bool IsPressed { get; private set; }
  public bool IsUp { get; private set; }
  public bool IsReleased { get; private set; }

  public static KeyStatus Up => new KeyStatus { IsUp = true };
  public static KeyStatus Released => new KeyStatus { IsUp = true, IsReleased = true };
  public static KeyStatus Down => new KeyStatus { IsDown = true };
  public static KeyStatus Pressed => new KeyStatus { IsDown = true, IsPressed = true };
}
public class KeyboardStateContainer : SimpleGameComponent
{
  public KeyboardState PreviousState { get; set; }
  public KeyboardState CurrentState { get; set; }

  public bool CapsLock => this.CurrentState.CapsLock;
  public bool NumLock => this.CurrentState.NumLock;

  public bool IsKeyDown(Keys key)
  {
    return this.CurrentState.IsKeyDown(key);
  }

  public KeyStatus this[Keys key]
  {
    get
    {
      if (WasKeyJustPressed(key))
        return KeyStatus.Pressed;

      if (WasKeyJustReleased(key))
        return KeyStatus.Released;

      if (IsKeyDown(key))
        return KeyStatus.Down;

      return KeyStatus.Up;
    }
  }

  public bool IsKeyUp(Keys key)
  {
    return this.CurrentState.IsKeyUp(key);
  }

  public bool WasKeyJustPressed(Keys key)
  {
    return this.PreviousState.IsKeyUp(key) && this.CurrentState.IsKeyDown(key);
  }
  public bool WasKeyJustReleased(Keys key)
  {
    return this.PreviousState.IsKeyDown(key) && this.CurrentState.IsKeyUp(key);
  }

  public Keys[] GetAllDownKeys()
  {
    return this.CurrentState.GetPressedKeys();
  }

  public override void Update(GameTime gameTime)
  {
    this.PreviousState = this.PreviousState;
    this.CurrentState = Keyboard.GetState();
  }
}
