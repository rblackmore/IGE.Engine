namespace IGE.Core.CoreSystems.Movement;

using IGE.Core.CoreSystems.Movement.Components;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

internal class ScalingSystem : EntityUpdateSystem
{
  private ComponentMapper<Scalable> scalableMapper;
  private ComponentMapper<Transform2> transformMapper;

  public ScalingSystem()
    : base(Aspect.All(typeof(Scalable), typeof(Transform2)))
  {

  }

  public override void Initialize(IComponentMapperService mapperService)
  {
    this.scalableMapper = mapperService.GetMapper<Scalable>();
    this.transformMapper = mapperService.GetMapper<Transform2>();
  }

  public override void Update(GameTime gameTime)
  {
    var deltaSeconds = gameTime.GetElapsedSeconds();

    foreach (var entityId in this.ActiveEntities)
    {
      var scalable = this.scalableMapper.Get(entityId);
      var transform = this.transformMapper.Get(entityId);

      transform.Scale += scalable.ScaleVelocity * deltaSeconds;
    }
  }
}
