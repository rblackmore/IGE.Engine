namespace IGE.Core.Player.Components;

using IGE.Core.CoreSystems.Input.Components;
using IGE.Core.CoreSystems.Input.Components.CommandStrategies;
using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework.Input;

public class PlayerCommands
{
  public Command MOVE_FORWARD { get; private set; } = new KeyDownCommand(Keys.W);
  public Command MOVE_BACKWARD { get; private set; } = new KeyDownCommand(Keys.S);
  public Command MOVE_LEFT { get; private set; } = new KeyDownCommand(Keys.A);
  public Command MOVE_RIGHT { get; private set; } = new KeyDownCommand(Keys.D);

  public Command GROW { get; set; } = new KeyPressedCommand(Keys.Up);
  public Command SHRINK { get; set; } = new KeyPressedCommand(Keys.Down);

  public void CheckStatus(InputManager inputManager)
  {
    this.MOVE_FORWARD.CheckStatus(inputManager);
    this.MOVE_BACKWARD.CheckStatus(inputManager);
    this.MOVE_LEFT.CheckStatus(inputManager);
    this.MOVE_RIGHT.CheckStatus(inputManager);
    this.GROW.CheckStatus(inputManager);
    this.SHRINK.CheckStatus(inputManager);
  }

  public void Reset()
  {
    this.MOVE_FORWARD.IsTriggered = false;
    this.MOVE_BACKWARD.IsTriggered = false;
    this.MOVE_LEFT.IsTriggered = false;
    this.MOVE_RIGHT.IsTriggered = false;
    this.GROW.IsTriggered = false;
    this.SHRINK.IsTriggered = false;
  }
}
