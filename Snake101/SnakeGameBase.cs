using Timer = System.Windows.Forms.Timer;

namespace Snake101;

/// <summary>
/// Stellt das Gerüst eines 2D Spiels dar
/// </summary>
public abstract class SnakeGameBase
{
  private readonly Screen screen;
  private readonly Random random = new();

  public readonly Timer GameUpdateTimer = new()
  {
    Interval = 100
  };

  protected SnakeGameBase(Screen screen)
  {
    this.screen = screen ?? throw new ArgumentOutOfRangeException(nameof(screen));
    this.screen.KeyUp += this.ScreenKeyUp;
    this.GameUpdateTimer.Tick += this.UpdateGameTimerTick;

    this.screen.Load += (_, _) =>
    {
      this.Start();
      this.GameUpdateTimer.Start();
    };
  }

  private void UpdateGameTimerTick(object? sender, EventArgs e)
  {
    this.UpdateInternal();
  }

  private void ScreenKeyUp(object? sender, KeyEventArgs e)
  {
    switch (e.KeyCode)
    {
      case Keys.Down:
      case Keys.S:
        this.OnArrowDown();
        break;
      case Keys.Up:
      case Keys.W:
        this.OnArrowUp();
        break;
      case Keys.Left:
      case Keys.A:
        this.OnArrowLeft();
        break;
      case Keys.Right:
      case Keys.D:
        this.OnArrowRight();
        break;
      case Keys.Enter:
        this.OnEnter();
        break;
    }
  }

  protected void ShowError(string message)
  {
    MessageBox.Show(message, "SNAKE101", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }

  protected void WriteMessage(string message)
  {
    this.screen.WriteMessage(message);
  }

  protected void SetPixel(int x, int y) => this.screen.SetPixel(x, y);
  protected void SetPixel(Point2D point) => this.SetPixel(point.X, point.Y);
  protected virtual void OnArrowUp()
  {
  }

  protected virtual void OnArrowDown()
  {
  }

  protected virtual void OnArrowLeft()
  {
  }
  protected virtual void OnArrowRight()
  {
  }

  protected virtual void OnEnter()
  {
  }

  protected int ResolutionX => Screen.ResolutionX;

  protected int ResolutionY => Screen.ResolutionY;

  protected int GetRandomNumber(int min, int max)
  {
    return this.random.Next(min, max);
  }

  protected virtual void Start()
  {
  }

  private void UpdateInternal()
  {
    this.screen.ClearPixels();

    this.Update();

    this.screen.RefreshScreen();
  }

  protected abstract void Update();
}