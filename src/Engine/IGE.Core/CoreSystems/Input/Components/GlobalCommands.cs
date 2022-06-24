namespace IGE.Core.CoreSystems.Input.Components;

using IGE.Core.CoreSystems.Input.Components.CommandStrategies;
using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework.Input;

public class GlobalCommands
{
  public Command QUIT_COMMAND { get; } = new KeyPressedCommand(Keys.Escape);

  public void CheckStatus(InputManager inputManager)
  {
    this.QUIT_COMMAND.CheckStatus(inputManager);
  }

  public void Reset()
  {
    this.QUIT_COMMAND.IsTriggered = false;
  }
}
