namespace IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Input;

public class InputManager: SimpleGameComponent
{
  public KeyboardStateExtended KeyboardState { get; private set; }

  public MouseStateExtended MouseState { get; private set; }

  public override void Update(GameTime gameTime)
  {
    this.KeyboardState = KeyboardExtended.GetState();
    this.MouseState = MouseExtended.GetState();
  }
}
