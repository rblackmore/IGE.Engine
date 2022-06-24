namespace IGE.GameEntry;

using IGE.Core;

public class Program
{
  [STAThread]
  public static void Main(string[] args)
  {
    using (GameAdmin game = new GameAdmin())
    {
      game.Run();
    }
  }
}
