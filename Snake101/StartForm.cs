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
    public StartForm()
    {
      InitializeComponent();
    }

    private void btnLevel1_Click(object sender, EventArgs e)
    {
      var screen = new Screen();

      var game = new Level1(screen);

      screen.ShowDialog();
    }

    private void btnLevel2_Click(object sender, EventArgs e)
    {
      var screen = new Screen();

      var game = new Level2(screen);

      screen.ShowDialog();
    
   
    }
  }

  public class PlayerHighScore
  {
    public string Player { get; set; }
    public int HighScore { get; set; }
    public string Level { get; set; }
  }

}
