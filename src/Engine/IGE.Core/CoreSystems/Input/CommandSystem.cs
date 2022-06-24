namespace IGE.Core.CoreSystems.Input;
using IGE.Core.CoreSystems.Input.Components;
using IGE.Core.Player.Components;

using Microsoft.Xna.Framework;

using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

internal class CommandSystem : EntityUpdateSystem
{
  private ComponentMapper<GlobalCommands> globalCommandMapper;
  private ComponentMapper<PlayerCommands> playerCommandMapper;

  public CommandSystem()
    : base(Aspect.One(typeof(GlobalCommands), typeof(PlayerCommands)))
  {

  }

  public override void Initialize(IComponentMapperService mapperService)
  {
    this.globalCommandMapper = mapperService.GetMapper<GlobalCommands>();
    this.playerCommandMapper = mapperService.GetMapper<PlayerCommands>();

    var entity = CreateEntity();
    entity.Attach(new GlobalCommands());
  }

  public override void Update(GameTime gameTime)
  {

    foreach (var globalCommands in this.globalCommandMapper.Components)
    {
      BuildGlobalCommand(globalCommands);
      HandleGlobalCommands(globalCommands);

    }

    //TODO: Find out why the first item in this collection is NULL.
    foreach (var playerCommand in this.playerCommandMapper.Components)
    {
      BuildPlayerCommands(playerCommand);
    }
  }

  private void BuildPlayerCommands(PlayerCommands playerCommands)
  {
    if (playerCommands is null)
      return;

    var inputManager = GameAdmin.InputManager;

    playerCommands.Reset();
    playerCommands.CheckStatus(inputManager);

  }

  private void BuildGlobalCommand(GlobalCommands globalCommands)
  {
    var inputManager = GameAdmin.InputManager;

    globalCommands.Reset();
    globalCommands.CheckStatus(inputManager);


  }

  private void HandleGlobalCommands(GlobalCommands globalCommand)
  {
    if (globalCommand.QUIT_COMMAND.IsTriggered)
    {
      GameAdmin.Game.Exit();
    }
  }
}
