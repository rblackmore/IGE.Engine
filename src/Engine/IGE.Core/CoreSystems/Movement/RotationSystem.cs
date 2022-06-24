namespace IGE.Core.CoreSystems.Movement;
using System;

using IGE.Core.CoreSystems.Movement.Components;

using Microsoft.Xna.Framework;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

internal class RotationSystem : EntityUpdateSystem
{
  private ComponentMapper<Rotatable> rotatableMapper;
  private ComponentMapper<Transform2> transformMapper;

  public RotationSystem()
    : base(Aspect.All(typeof(Rotatable), typeof(Transform2)))
  {

  }

  public override void Initialize(IComponentMapperService mapperService)
  {
    this.rotatableMapper = mapperService.GetMapper<Rotatable>();
    this.transformMapper = mapperService.GetMapper<Transform2>();
  }

  public override void Update(GameTime gameTime)
  {
    var deltaSeconds = gameTime.GetElapsedSeconds();

    foreach (var entityId in this.ActiveEntities)
    {
      var rotatable = this.rotatableMapper.Get(entityId);
      var transform = this.transformMapper.Get(entityId);

      transform.Rotation += rotatable.RotationVelocity * deltaSeconds;
    }
  }
}
