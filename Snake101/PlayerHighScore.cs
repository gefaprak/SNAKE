using System.Text.Json;

namespace Snake101;

public class PlayerHighScore
{
  public string Player { get; set; }
  public int HighScore { get; set; }
  public string Level { get; set; }
}

public class PlayerHighScoreDatabase
{

  private readonly List<PlayerHighScore> highScores = new();

  private readonly string dbPath = Path.Combine(Path.GetDirectoryName(typeof(PlayerHighScoreDatabase).Assembly.Location), "highscores.json");

  public IReadOnlyCollection<PlayerHighScore> HighScores => this.highScores;

  public PlayerHighScoreDatabase()
  {
    try
    {
      var text = File.ReadAllText(this.dbPath);
      this.highScores = JsonSerializer.Deserialize<List<PlayerHighScore>>(text);
    }
    catch
    {
    }
  }

  public void Save()
  {
    try
    {
      var text = JsonSerializer.Serialize(this.highScores);
      File.WriteAllText(this.dbPath, text);
    }
    catch
    {
    }
  }

  public void RegisterPlayedGame(string level, string player, int score)
  {
    var existing = this.highScores.FirstOrDefault(x => x.Player == player && x.Level == level);

    if (existing is null)
    {
      this.highScores.Add(new PlayerHighScore()
      {
        HighScore = score,
        Level = level,
        Player = player
      });
    }
    else if (existing.HighScore < score)
    {
      existing.HighScore = score;
    }

    this.Save();
  }
}