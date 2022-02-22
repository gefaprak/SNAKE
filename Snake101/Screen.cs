namespace Snake101;

public class Screen : Form
{
  public const int ResolutionX = 32;
  public const int ResolutionY = 32;

  private const int PixelSize = 8;
  private const int PixelBorder = 1;

  private readonly bool[,] pixels = new bool[ResolutionX, ResolutionY];

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
      this.pixels[x, y] = false;
  }

  public void SetPixel(int x, int y)
  {
    if (x >= ResolutionX)
      throw new Exception($"X: {x} >= {ResolutionX}");

    if (y >= ResolutionY)
      throw new Exception($"Y: {y} >= {ResolutionY}");

    if (x < 0)
      throw new Exception($"X: {x} < 0");

    if (y < 0)
      throw new Exception($"Y: {y} < 0");

    this.pixels[x, y] = true;
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
        if (!this.pixels[x, y])
          continue;

        var pixelX = x * PixelSize + PixelBorder;
        var pixelY = y * PixelSize + PixelBorder;

        var drawablePixelSize = PixelSize - 2 * PixelBorder;

        e.Graphics.FillRectangle(Brushes.Black, pixelX, pixelY, drawablePixelSize, drawablePixelSize);
      }
    }

    e.Graphics.DrawString(this.message, this.Font, Brushes.Black, new Point(2, ResolutionY * PixelSize + 2));
  }
}