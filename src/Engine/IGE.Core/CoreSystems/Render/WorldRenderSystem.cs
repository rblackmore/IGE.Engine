namespace IGE.Core.CoreSystems.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Sprites;

public class WorldRenderSystem : EntityDrawSystem
{
  private readonly GraphicsDevice graphicsDevice;
  private readonly SpriteBatch spriteBatch;

  private ComponentMapper<Sprite> spriteMapper;
  private ComponentMapper<Transform2> transformMapper;

  public WorldRenderSystem(GraphicsDevice graphicsDevice)
    : base(Aspect.All(typeof(Sprite), typeof(Transform2)))
  {
    this.graphicsDevice = graphicsDevice;
    this.spriteBatch = new SpriteBatch(this.graphicsDevice);

  }
  public override void Initialize(IComponentMapperService mapperService)
  {
    this.spriteMapper = mapperService.GetMapper<Sprite>();
    this.transformMapper = mapperService.GetMapper<Transform2>();
  }

  public override void Draw(GameTime gameTime)
  {
    this.graphicsDevice.Clear(Color.CadetBlue * 0.4f);

    this.spriteBatch.Begin();

    foreach (var entityId in this.ActiveEntities)
    {
      var sprite = this.spriteMapper.Get(entityId);
      var transform = this.transformMapper.Get(entityId);

      this.spriteBatch.Draw(sprite, transform);
    }
    this.spriteBatch.End();
  }
}
