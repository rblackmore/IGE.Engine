namespace IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

public class MouseStateContainer : SimpleGameComponent
{
  public MouseState PreviousState { get; set; }
  public MouseState CurrentState { get; set; }

  public override void Update(GameTime gameTime)
  {
    this.PreviousState = this.CurrentState;
    this.CurrentState = Mouse.GetState();
  }
}
