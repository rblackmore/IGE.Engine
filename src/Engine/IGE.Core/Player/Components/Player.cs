namespace IGE.Core.Player.Components;

using Microsoft.Xna.Framework;

public enum Scaling
{
  None,
  Growing,
  Shrinking
}

public class Player
{
  public Player(PlayerIndex playerIndex)
  {
    PlayerIndex = playerIndex;
  }

  public PlayerIndex PlayerIndex { get; set; }
  public Scaling Scaling { get; set; }
}
