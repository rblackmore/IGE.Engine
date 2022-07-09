namespace IGE.Core.CoreSystems.Input.Components.CommandStrategies;

using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework.Input;

public class KeyPressedCommand : Command
{
  public KeyPressedCommand(Keys key)
    : base(key)
  {
  }

  public override void CheckStatus(InputManager inputManager)
  {
    IsTriggered = inputManager.KeyboardState.WasKeyJustDown(this.Key);
  }
}
