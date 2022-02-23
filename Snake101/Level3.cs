using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Snake101;

public class Level3 : SnakeGameBase
{
  private int score = 0;
  private bool moveUp = false;
  private bool moveLeft = false;
  private bool moveRight = true;
  private bool moveDown = false;
  private Point2D item;
  private List<Point2D> schlange;
  private bool ende;
  private bool enter;
  private List<Point2D> hindernisse = new();

  public override string Level { get; } = "Level 3";


  public Level3(Screen screen)
    : base(screen)
  {
  }

  protected override void Start()
  {
    ErzeugeItem();
    ErzeugeSchlange();
    ErzeugenWand();
  }

  private void ErzeugeSchlange()
  {
    schlange = new List<Point2D>();

    schlange.Add(new Point2D(16, 4));
    schlange.Add(new Point2D(15, 4));
    schlange.Add(new Point2D(14, 4));
    schlange.Add(new Point2D(13, 4));
    schlange.Add(new Point2D(12, 4));

  }

  private void ErzeugeItem()
  {
    item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
    ÜberprüfeItemHindernis();
  }

  private void ErzeugenWand()
  {
    for (int i = 5; i < 27; i++)
    {
      hindernisse.Add(new Point2D(5, i));
      hindernisse.Add(new Point2D(26, i));
    }
    for (int i = 6; i < 26; i++)
    {
      hindernisse.Add(new Point2D(i, 26));
    }
    for (int i = 5; i < 22; i++)
    {
      hindernisse.Add(new Point2D(10, i));
      hindernisse.Add(new Point2D(21, i));
    }
    for (int i = 11; i < 21; i++)
    {
      hindernisse.Add(new Point2D(i, 5));
    }
  }
  private void MaleWand()
  {
    foreach (var hindernis in hindernisse)
    {
      this.SetPixel(hindernis);
    }
  }
  protected override void Update()
  {
    // überprüfen ob das spiel beendet ist
    ÜberprüfeKollision();
    // wenn das spiel noch läuft
    // dann bewege die schlange
    if (!ende)
    {
      this.BewegeSchlange();
    }
    this.MaleWand();

    this.ÜberprüfeNeustart();

    this.MaleItem();
    this.MaleSchlange();

    if (!ende)
      this.WriteMessage("SCORE:" + score);
  }

  private void MaleSchlange()
  {
    for (int i = 0; i < this.schlange.Count; i++)
    {
      this.SetPixel(this.schlange[i].X, this.schlange[i].Y, Color.Blue);
    }
  }

  private void MaleItem()
  {
    this.SetPixel(item.X, item.Y, Color.Crimson);
  }



  void ÜberprüfeKollision()
  {
    var kopf = this.schlange.First();


    foreach (var hindernis in hindernisse)
    {
      if (hindernis == kopf)
      {
        this.Zurücksetzen();
        return;
      }
    }
    for (int i = 1; i < schlange.Count; i++)
    {
      if (schlange.First() == schlange[i])
      {
        this.Zurücksetzen();
        return;
      }


      ende = false;
    }
  }

  private void Zurücksetzen()
  {
    ende = true;
    this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
    score = 0;
    GameUpdateTimer.Interval = 100;
  }

  private void BewegeSchlange()
  {
    var schwanz = this.schlange.Last();
    var kopf = this.schlange.First();
    Point2D neuerKopf = new Point2D(0, 0);

    if (moveUp)
    {
      if (kopf.Y == 0)
      {
        neuerKopf = new Point2D(kopf.X, 31);
      }
      else
      {
        neuerKopf = new Point2D(kopf.X, kopf.Y - 1);
      }
      ÜberprüfeSchlangeItemKollision(schwanz, kopf);

    }
    else if (moveRight)
    {
      if (kopf.X == 31)
      {
        neuerKopf = new Point2D(0, kopf.Y);
      }
      else
      {
        neuerKopf = new Point2D(kopf.X + 1, kopf.Y);
      }
      ÜberprüfeSchlangeItemKollision(schwanz, kopf);

    }
    else if (moveDown)
    {
      if (kopf.Y == 31)
      {
        neuerKopf = new Point2D(kopf.X, 0);
      }
      else
      {
        neuerKopf = new Point2D(kopf.X, kopf.Y + 1);
      }
      ÜberprüfeSchlangeItemKollision(schwanz, kopf);
    }
    else if (moveLeft)
    {
      if (kopf.X == 0)
      {
        neuerKopf = new Point2D(31, kopf.Y);
      }
      else
      {
        neuerKopf = new Point2D(kopf.X - 1, kopf.Y);
      }

      ÜberprüfeSchlangeItemKollision(schwanz, kopf);
    }

    // Insert = Einfügen
    // Add Hinzufügen an letzter stelle
    this.schlange.Insert(0, neuerKopf);
    this.schlange.Remove(schwanz);
  }

  private void ÜberprüfeSchlangeItemKollision(Point2D schwanz, Point2D kopf)
  {
    if (kopf == item)
    {
      schlange.Add(schwanz);
      item = new Point2D(GetRandomNumber(0, 31), GetRandomNumber(0, 31));
      ÜberprüfeItemHindernis();

      score += 1;

      if (score > this.HighScore)
        this.HighScore = score;

      if (GameUpdateTimer.Interval <= 10)
      {
        GameUpdateTimer.Interval -= 5;
      }
    }
  }

  private void ÜberprüfeItemHindernis()
  {
    while (hindernisse.Contains(item))
    {
      item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
    }
  }

  protected override void OnArrowDown()
  {
    if (moveUp == true)
    {
      return;
    }
    else
    {
      moveDown = true;
      moveLeft = false;
      moveRight = false;
      moveUp = false;
    }

  }

  protected override void OnArrowUp()
  {
    if (moveDown == true)
    {
      return;
    }
    else
    {
      moveDown = false;
      moveLeft = false;
      moveRight = false;
      moveUp = true;
    }

    // wird aufgerufen, wenn die Pfeiltaste nach oben gedrückt wurde
  }

  protected override void OnArrowLeft()
  {
    if (moveRight == true)
    {
      return;
    }
    else
    {
      moveDown = false;
      moveLeft = true;
      moveRight = false;
      moveUp = false;
    }

    // wird aufgerufen, wenn die Pfeiltaste nach links gedrückt wurde
  }

  protected override void OnArrowRight()
  {
    if (moveLeft == true)
    {
      return;
    }
    else
    {
      moveDown = false;
      moveLeft = false;
      moveRight = true;
      moveUp = false;
    }

    // wird aufgerufen, wenn die Pfeiltaste nach rechts gedrückt wurde
  }

  protected override void OnEnter()
  {
    // wird aufgerufen, wenn die ENTER Taste gedrückt wurde
    enter = true;
  }
  private void ÜberprüfeNeustart()
  {
    if (enter == true && ende == true)
    {
      //alte schlange verschwinden lassen
      //neue schlange erscheinen lassen 
      Start();

      moveDown = false;
      moveLeft = false;
      moveRight = true;
      moveUp = false;

      ende = false;
      enter = false;
    }
    else
    {
      enter = false;
    }
  }
}
