namespace IGE.Core.Utilities.Input.Pad;

using Microsoft.Xna.Framework.Input;

public struct GamePadStateExtended
{
  private GamePadStateWrapper state;

  public GamePadButtonsExtended Buttons;

  public GamePadStateExtended(GamePadStateWrapper state)
  {
    this.state = state;
    this.Buttons = new GamePadButtonsExtended();
  }

  public bool IsConnected => this.state.CurrentState.IsConnected;
}
