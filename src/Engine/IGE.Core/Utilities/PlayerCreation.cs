namespace IGE.Core.Utilities;

using IGE.Core.CoreSystems.Movement.Components;
using IGE.Core.Player.Components;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;
using MonoGame.Extended.Sprites;

public static class PlayerCreation
{
  public static int CreatePlayerEntity(PlayerIndex index, string assetName)
  {
    var entity = GameAdmin.Game.World.CreateEntity();

    var texture = GameAdmin.Game.Content.Load<Texture2D>(assetName);

    entity.Attach(new Sprite(texture));
    entity.Attach(new Player(index));
    entity.Attach(new Transform2(position: new Vector2(250), rotation: 0.0f, scale: new Vector2(0.5f)));
    entity.Attach(new PlayerCommands());
    entity.Attach(new Movable(Vector2.Zero, 150f));
    entity.Attach(new Scalable());
    entity.Attach(new Rotatable());

    return entity.Id;
  }
}
