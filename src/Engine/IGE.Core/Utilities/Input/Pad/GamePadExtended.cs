namespace IGE.Core.Utilities.Input.Pad;

using Microsoft.Xna.Framework;

public struct GamePadButtonState
{
  public bool IsUp { get; private set; }
  public bool IsReleased { get; private set; }
  public bool IsDown { get; private set; }
  public bool IsPressed { get; private set; }

  public static GamePadButtonState Up 
    => new GamePadButtonState { IsUp = true };

  public static GamePadButtonState Released 
    => new GamePadButtonState { IsUp = true, IsReleased = true };

  public static GamePadButtonState Down 
    => new GamePadButtonState { IsDown = true };

  public static GamePadButtonState Pressed 
    => new GamePadButtonState { IsDown = true, IsReleased = true };
}

public static class GamePadExtended
{
  private static Dictionary<PlayerIndex, GamePadStateWrapper> gamepadStates = new();

  public static GamePadStateExtended GetState(PlayerIndex playerIdx)
  {
    if (!gamepadStates.ContainsKey(playerIdx))
      return default;

    return new GamePadStateExtended(gamepadStates[playerIdx]);
  }

  public static void AddGamepad(PlayerIndex playerIdx)
  {
    gamepadStates[playerIdx] = new GamePadStateWrapper(playerIdx);
  }

  public static void RemoveGamePad(PlayerIndex playerIdx)
  {
    if (gamepadStates.ContainsKey(playerIdx))
      gamepadStates.Remove(playerIdx);
  }

  public static void Refresh()
  {
    foreach (var state in gamepadStates.Values)
    {
      state.Refresh();
    }
  }
}
