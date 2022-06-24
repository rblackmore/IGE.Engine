namespace IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;

using MonoGame.Extended;

public class InputManager: SimpleGameComponent
{
  public InputManager()
  {
    this.KeyboardState = new KeyboardStateContainer();
    this.GamePadState = new GamepadStateContainer();
    this.MouseState = new MouseStateContainer();
  }

  public KeyboardStateContainer KeyboardState { get; set; }
  public GamepadStateContainer GamePadState { get; set; }
  public MouseStateContainer MouseState { get; set; }

  public override void Update(GameTime gameTime)
  {
    this.KeyboardState.Update(gameTime);
    this.MouseState.Update(gameTime);
    this.GamePadState.Update(gameTime);
  }
}
