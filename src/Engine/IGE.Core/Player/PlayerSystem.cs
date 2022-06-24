namespace IGE.Core.Player;
using System;

using IGE.Core.CoreSystems.Movement.Components;
using IGE.Core.Player.Components;
using IGE.Core.Utilities;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

internal class PlayerSystem : EntityUpdateSystem
{
  private ComponentMapper<Player> playerMapper;
  private ComponentMapper<Movable> movableMapper;
  private ComponentMapper<Rotatable> rotatableMapper;
  private ComponentMapper<Scalable> scalableMapper;
  private ComponentMapper<PlayerCommands> playerCommandsMapper;

  public PlayerSystem()
    : base(Aspect.All(
      typeof(Player),
      typeof(Movable),
      typeof(Rotatable),
      typeof(Scalable),
      typeof(PlayerCommands),
      typeof(Transform2)))
  {

  }

  public override void Initialize(IComponentMapperService mapperService)
  {
    this.playerMapper = mapperService.GetMapper<Player>();
    this.movableMapper = mapperService.GetMapper<Movable>();
    this.rotatableMapper = mapperService.GetMapper<Rotatable>();
    this.scalableMapper = mapperService.GetMapper<Scalable>();
    this.playerCommandsMapper = mapperService.GetMapper<PlayerCommands>();
  }

  public override void Update(GameTime gameTime)
  {
    var deltaSeconds = gameTime.GetElapsedSeconds();

    foreach (var entityId in this.ActiveEntities)
    {
      var player = playerMapper.Get(entityId);
      var commands = this.playerCommandsMapper.Get(entityId);
      var movable = this.movableMapper.Get(entityId);
      var scalable = this.scalableMapper.Get(entityId);

      MovePlayer(player, commands, movable);
    }
  }

  private static void MovePlayer(Player player, PlayerCommands commands, Movable movable)
  {
    Vector2 direciton = Vector2.Zero;

    if (commands.MOVE_FORWARD.IsTriggered)
      direciton.Y -= 1;
    
    if (commands.MOVE_BACKWARD.IsTriggered)
      direciton.Y += 1;

    if (commands.MOVE_LEFT.IsTriggered)
      direciton.X -= 1;

    if (commands.MOVE_RIGHT.IsTriggered)
      direciton.X += 1;

    movable.Direction = direciton;
  }
}
