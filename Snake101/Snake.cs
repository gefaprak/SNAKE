using System.Text.Json;

namespace Snake101;

public class Snake
{
  public List<Point2D> Elements { get; } = new();

  public Point2D Head => this.Elements.First();
  public Point2D Tail => this.Elements.Last();

  public int Length => this.Elements.Count;

  public Direction Direction { get; set; } = Direction.Right;

  public Snake(Point2D start, int length)
  {
    for (var i = 0; i < length; i++)
      this.Elements.Insert(0, new Point2D(start.X + i, start.Y));
  }

  public bool HitWall(int resolutionX, int resolutionY)
  {
    if (this.Head.X == 0)
      return true;

    if (this.Head.Y == 0)
      return true;

    if (this.Head.X == resolutionX - 1)
      return true;

    if (this.Head.Y == resolutionY - 1)
      return true;

    return false;
  }

  public bool HitItself()
  {
    for (var i = 1; i < this.Length; i++)
      if (this.Elements[i] == this.Head)
        return true;

    return false;
  }

  public bool HitOtherSnake(Snake other)
  {
    foreach (var element in other.Elements)
      if (element == this.Head)
        return true;

    return false;
  }

  // returns true if item was hit
  public bool Move(Point2D item)
  {
    var newHead = new Point2D(0, 0);
    switch (this.Direction)
    {
      case Direction.Up:
        newHead = new Point2D(this.Head.X, this.Head.Y - 1);
        break;
      case Direction.Down:
        newHead = new Point2D(this.Head.X, this.Head.Y + 1);
        break;
      case Direction.Left:
        newHead = new Point2D(this.Head.X - 1, this.Head.Y);
        break;
      case Direction.Right:
        newHead = new Point2D(this.Head.X + 1, this.Head.Y);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }

    var hitItem = item == this.Tail;

    this.Elements.Insert(0, newHead);

    if (!hitItem)
      this.Elements.Remove(this.Tail);

    return hitItem;
  }

  public static string ToJson(Snake snake)
  {
    return JsonSerializer.Serialize(snake);
  }

  public static Snake FromJson(string jsonSnake)
  {
    return JsonSerializer.Deserialize<Snake>(jsonSnake);
  }
}