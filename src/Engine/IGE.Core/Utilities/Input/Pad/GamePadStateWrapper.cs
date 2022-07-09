namespace IGE.Core.Utilities.Input.Pad;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public struct GamePadStateWrapper
{
  private PlayerIndex playerIdx;

  public GamePadState CurrentState { get; private set; }
  public GamePadState PreviousState { get; private set; }

  public GamePadStateWrapper(PlayerIndex playerIdx)
  {
    this.playerIdx = playerIdx;
    this.CurrentState = GamePad.GetState(playerIdx);
    this.PreviousState = GamePad.GetState(playerIdx);
  }

  public void Refresh()
  {
    this.PreviousState = this.CurrentState;
    this.CurrentState = GamePad.GetState(this.playerIdx);
  }
}
