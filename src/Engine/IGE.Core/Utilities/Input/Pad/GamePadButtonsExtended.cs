namespace IGE.Core.Utilities.Input.Pad;

using Microsoft.Xna.Framework.Input;

public struct GamePadButtonsExtended
{
  private readonly GamePadButtons previousButtonsState;
  private readonly GamePadButtons currentButtonsState;

  public GamePadButtonsExtended(
    GamePadButtons currentButtonsState,
    GamePadButtons previousButtonsState)
  {
    this.previousButtonsState = previousButtonsState;
    this.currentButtonsState = currentButtonsState;
  }

  public GamePadButtonState A
  {
    get
    {
      if (WasJustPressed(m => m.A))
        return GamePadButtonState.Pressed;

      if (WasJustReleased(m => m.A))
        return GamePadButtonState.Released;

      if (IsPressed(m => m.A))
        return GamePadButtonState.Down;

      return GamePadButtonState.Up;
    }
  }

  private bool IsPressed(Func<GamePadButtons, ButtonState> button)
    => button(this.currentButtonsState) == ButtonState.Pressed;

  private bool IsReleased(Func<GamePadButtons, ButtonState> button)
    => button(this.currentButtonsState) == ButtonState.Released;

  private bool WasJustPressed(Func<GamePadButtons, ButtonState> button)
    => button(this.previousButtonsState) == ButtonState.Released &&
       button(this.currentButtonsState) == ButtonState.Pressed;

  private bool WasJustReleased(Func<GamePadButtons, ButtonState> button)
  => button(this.previousButtonsState) == ButtonState.Pressed &&
     button(this.currentButtonsState) == ButtonState.Released;
}
