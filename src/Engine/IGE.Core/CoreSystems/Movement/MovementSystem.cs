namespace IGE.Core.CoreSystems.Movement;

using IGE.Core.CoreSystems.Movement.Components;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

public class MovementSystem : EntityUpdateSystem
{
  private ComponentMapper<Movable> movableMapper;
  private ComponentMapper<Transform2> transformMapper;

  public MovementSystem()
    : base(Aspect.All(typeof(Transform2), typeof(Movable)))
  {
  }

  public override void Initialize(IComponentMapperService mapperService)
  {
    this.movableMapper = mapperService.GetMapper<Movable>();
    this.transformMapper = mapperService.GetMapper<Transform2>();
  }

  public override void Update(GameTime gameTime)
  {
    var deltaSeconds = gameTime.GetElapsedSeconds();

    foreach (var entityId in this.ActiveEntities)
    {
      var movable = this.movableMapper.Get(entityId);
      var transform = this.transformMapper.Get(entityId);

      var normalized = movable.GetNormalizedDirection();
      var scaler = normalized * movable.Velocity;

      transform.Position += scaler * deltaSeconds;
    }
  }
}
