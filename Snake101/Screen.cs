namespace Snake101;

public class Screen : Form
{
  public const int ResolutionX = 32;
  public const int ResolutionY = 32;

  private const int PixelSize = 8;
  private const int PixelBorder = 1;


  private readonly Color?[,] pixels = new Color?[ResolutionX, ResolutionY];

  private string message;

  protected override CreateParams CreateParams
  {
    get
    {
      var cp = base.CreateParams;
      cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
      return cp;
    }
  }

  public Screen()
  {
    this.BackColor = Color.White;
    this.Width = ResolutionX * PixelSize + 20;
    this.Height = ResolutionY * PixelSize + 60;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "SNAKE101";
  }

  public void ClearPixels()
  {
    for (var x = 0; x < ResolutionX; x++)
      for (var y = 0; y < ResolutionY; y++)
        this.pixels[x, y] = null;
  }

  public void SetPixel(int x, int y, Color? color)
  {
    if (x >= ResolutionX || y >= ResolutionY)
      throw new ArgumentOutOfRangeException();

    if (x < 0 || y < 0)
      throw new ArgumentOutOfRangeException();

    this.pixels[x, y] = color ?? Color.Black;
  }

  public void WriteMessage(string message)
  {
    this.message = message;
  }

  public void RefreshScreen()
  {
    this.Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);

    for (var x = 0; x < ResolutionX; x++)
    {
      for (var y = 0; y < ResolutionY; y++)
      {
        if (this.pixels[x, y] is not Color color)
          continue;

        var pixelX = x * PixelSize + PixelBorder;
        var pixelY = y * PixelSize + PixelBorder;

        var drawablePixelSize = PixelSize - 2 * PixelBorder;
        using var brush = new SolidBrush(color);
        e.Graphics.FillRectangle(brush, pixelX, pixelY, drawablePixelSize, drawablePixelSize);
      }
    }

    e.Graphics.DrawString(this.message, this.Font, Brushes.Black, new Point(2, ResolutionY * PixelSize + 2));
  }
}