namespace IGE.Core.CoreSystems.Input.Components;

using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework.Input;

public abstract class Command
{
  public Command(Keys key)
  {
    this.Key = key;
  }

  public Keys Key { get; set; }
  public bool IsTriggered { get; set; }
  public abstract void CheckStatus(InputManager inputManager);
}
