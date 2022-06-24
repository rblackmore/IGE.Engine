namespace IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

public class GamePadStateTracker
{
  public GamePadState PreviousState { get; set; }
  public GamePadState CurrentState { get; set; }
}

public class GamepadStateContainer : SimpleGameComponent
{

  private Dictionary<PlayerIndex, GamePadStateTracker> gamePads = 
    new Dictionary<PlayerIndex, GamePadStateTracker>();

  public override void Update(GameTime gameTime)
  {

    foreach (var pad in this.gamePads)
    {
      pad.Value.PreviousState = pad.Value.CurrentState;
      pad.Value.CurrentState = GamePad.GetState(pad.Key);
    }
  }

  public void AddGamePad(PlayerIndex player)
  {
    this.gamePads.Add(player, new GamePadStateTracker());
  }

  public void RemoveGamePad(PlayerIndex player)
  {
    this.gamePads.Remove(player);
  }
}
