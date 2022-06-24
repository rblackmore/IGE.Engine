namespace IGE.Core.CoreSystems.Input.Components.CommandStrategies;

using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework.Input;

internal class KeyDownCommand : Command
{
  public KeyDownCommand(Keys key) 
    : base(key)
  {
  }

  public override void CheckStatus(InputManager inputManager)
  {
    this.IsTriggered = inputManager.KeyboardState.IsKeyDown(this.Key);
  }
}
