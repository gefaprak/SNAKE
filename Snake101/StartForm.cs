using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake101
{
  public partial class StartForm : Form
  {
    private readonly PlayerHighScoreDatabase highScoreDb = new();
   
    public StartForm()
    {
      this.InitializeComponent();
      this.UpdateHighScoresListView();
    }

    private void btnLevel1_Click(object sender, EventArgs e)
    {
      if (!this.HasPlayername())
        return;

      var screen = new Screen();

      var game = new Level1(screen);

      screen.ShowDialog();
      this.highScoreDb.RegisterPlayedGame(game.Level, this.txtPlayername.Text, game.HighScore);
      this.UpdateHighScoresListView();
    }

    private void btnLevel2_Click(object sender, EventArgs e)
    {
      if (!this.HasPlayername())
        return;

      var screen = new Screen();

      var game = new Level2(screen);

      screen.ShowDialog();

      this.highScoreDb.RegisterPlayedGame(game.Level, this.txtPlayername.Text, game.HighScore);
      this.UpdateHighScoresListView();
    }


    private void UpdateHighScoresListView()
    {
      this.lsvHighscores.Items.Clear();

      foreach (var highscore in this.highScoreDb.HighScores)
      {
        var item = new ListViewItem()
        {
          Text = highscore.Player,
          SubItems = { highscore.Level, highscore.HighScore.ToString() }
        };

        this.lsvHighscores.Items.Add(item);
      }
    }

    private bool HasPlayername()
    {
      if (string.IsNullOrWhiteSpace(this.txtPlayername.Text))
      {
        MessageBox.Show("Bitte Spielername eingeben", "SNAKE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    private void btnLevel3_Click(object sender, EventArgs e)
    {
      if (!this.HasPlayername())
        return;

      var screen = new Screen();

      var game = new Level3(screen);

      screen.ShowDialog();
      this.highScoreDb.RegisterPlayedGame(game.Level, this.txtPlayername.Text, game.HighScore);
      this.UpdateHighScoresListView();
    }

    private void lsvHighscores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
