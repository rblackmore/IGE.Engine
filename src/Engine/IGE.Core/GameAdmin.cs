namespace IGE.Core;

using IGE.Core.CoreSystems.Input;
using IGE.Core.CoreSystems.Movement;
using IGE.Core.CoreSystems.Render;
using IGE.Core.Player;
using IGE.Core.Utilities;
using IGE.Core.Utilities.Input;

using Microsoft.Xna.Framework;

using MonoGame.Extended.Entities;

public class GameAdmin : Game
{
  public World? World { get; private set; }

  public static InputManager? InputManager { get; private set; }
  public static GameAdmin? Game { get; private set; }

  private GraphicsDeviceManager graphicsManager;

  public GameAdmin()
  {
    this.graphicsManager = new GraphicsDeviceManager(this);
    this.Content.RootDirectory = "Content";
    this.IsFixedTimeStep = true;
    this.IsMouseVisible = true;
  }

  protected override void Initialize()
  {
    this.graphicsManager.PreferredBackBufferHeight = 800;
    this.graphicsManager.PreferredBackBufferWidth = 1200;
    this.graphicsManager.ApplyChanges();

    GameAdmin.InputManager = new InputManager();
    GameAdmin.Game = this;

    this.World = new WorldBuilder()
      .AddSystem(new CommandSystem())
      .AddSystem(new MovementSystem())
      .AddSystem(new RotationSystem())
      .AddSystem(new ScalingSystem())
      .AddSystem(new PlayerSystem())
      .AddSystem(new WorldRenderSystem(this.GraphicsDevice))
      .Build();

    PlayerCreation.CreatePlayerEntity(PlayerIndex.One, "BlueTank");

    this.Components.Add(GameAdmin.InputManager);
    this.Components.Add(this.World);

    base.Initialize();
  }
}
