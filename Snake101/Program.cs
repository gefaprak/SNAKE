using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.Json;

namespace Snake101
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

      var highscore1 = new PlayerHighScore()
      {
        HighScore = 1,
        Level = "Level1",
        Player = "Felix"
      };

      var highscore2 = new PlayerHighScore()
      {
        HighScore = 10,
        Level = "Level2",
        Player = "Niklas"
      };

      var highscores = new [] { highscore1, highscore2 };

      var json = JsonSerializer.Serialize(highscores);

      Application.EnableVisualStyles();
      //var screen = new Screen();
      //var game = new Level1(screen);
      Application.Run(new StartForm());
    }
  }
}