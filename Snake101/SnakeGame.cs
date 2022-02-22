using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Snake101;

public class SnakeGame : SnakeGameBase
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
  private List<Point2D> hindernisse;


  public SnakeGame(Screen screen)
    : base(screen)
  {
  }

  protected override void Start()
  {
    ErzeugeHindernisse();
    ErzeugeItem();
    ErzeugeSchlange();
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
    while(hindernisse.Contains(item))
    {
      item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
    }
    
  }



  protected override void Update()
  {




    // überprüfen ob das spiel beendet ist
    death();
    // wenn das spiel noch läuft
    // dann bewege die schlange
    if (ende == false)
    {
      this.BewegeSchlange();
    }


    this.restset();

    this.MaleHindernisse();
    this.MaleWände();
    this.MaleItem();
    this.MaleSchlange();

    if(ende == false)
    this.WriteMessage("SCORE:" + score);
    //first item spowned

    // wird in einer endlosschleife im abstand von 100 millisekunden aufgerufen.
    // hier muss das spiel neu gezeichnet werden
    // und der spielstand verändert werden

    // Zeichne Wände
    // Zeichne Schlange
    // Zeichne Happen

    // Aktualisiere Schlangenposition
    // Überprüfe ob Schlange mit Wand kollidiert
    // Überprüfe ob Schlange mit sich selbst kollidiert
  }




  private void MaleSchlange()
  {
    for (int i = 0; i < this.schlange.Count; i++)
    {
      this.SetPixel(this.schlange[i].X, this.schlange[i].Y);
    }
  }


  private void MaleItem()
  {
    this.SetPixel(item.X, item.Y);
  }

  private void MaleWände()
  {
    //create walls

    for (int i = 1; i < 32; i = i + 1)
    {
      this.SetPixel(x: i, y: 0);
    }
    for (int i = 0; i < 31; i = i + 1)
    {
      this.SetPixel(x: 0, y: i);
    }
    for (int i = 0; i < 31; i = i + 1)
    {
      this.SetPixel(x: i, y: 31);
    }
    for (int i = 1; i < 32; i = i + 1)
    {
      this.SetPixel(x: 31, y: i);
    }
  }

  private void ErzeugeHindernisse()
  {
    hindernisse = new List<Point2D>();
    for (int i = 13; i <= 19; i = i + 1)
    {
      this.hindernisse.Add(new Point2D( 16, i));

    }
    for (int i = 13; i <= 19; i = i + 1)
    {
      this.hindernisse.Add(new Point2D( i, 16));
    }


    //diagonalen

    for (int i = 4; i <= 9; i = i + 1)
    {
      this.SetPixel(x: i, y: i);
      this.hindernisse.Add(new Point2D( i, i));
    }

    for (int i = 27; i >= 22; i = i - 1)
    {
      this.hindernisse.Add(new Point2D( i, i));
    }

    for (int i = 27; i >= 22; i = i - 1)
    {
      this.SetPixel(x: 31 - i, y: i);
      this.hindernisse.Add(new Point2D(31 - i, i));
    }

    for (int i = 27; i >= 22; i = i - 1)
    {
      this.hindernisse.Add(new Point2D( i, 31 - i));
    }

  }

  private void MaleHindernisse()
  {
    foreach (var hindernis in hindernisse)
      this.SetPixel(hindernis);

  }
  void death()
  {
    var kopf = this.schlange.First();
    if (kopf.X >= 0 && kopf.X <= 31 && kopf.Y == 0)
    {
      ende = true;
      this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
      score = 0;
      GameUpdateTimer.Interval = 100;
    }
    else if (kopf.Y >= 0 && kopf.Y <= 31 && kopf.X == 0)
    {
      ende = true;
      this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
      score = 0;
      GameUpdateTimer.Interval = 100;
    }
    else if (kopf.X >= 0 && kopf.X <= 31 && kopf.Y == 31)
    {
      ende = true;
      this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
      score = 0;
      GameUpdateTimer.Interval = 100;
    }
    else if (kopf.Y >= 0 && kopf.Y <= 31 && kopf.X == 31)
    {
      ende = true;
      this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
      score = 0;
      GameUpdateTimer.Interval = 100;
    }
    else
    {

      foreach (var hindernis in hindernisse)
      {
        if(hindernis == kopf)
        {
          ende = true;
          this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
          score = 0;
          return;
        }
      }
        for (int i = 1; i < schlange.Count; i++)
      {
        if (schlange.First() == schlange[i])
        {
          ende = true;
          this.WriteMessage("YOU ARE DEAD!!! if you want to play again Press RETURN");
          score = 0;
          return;
        }
      }

      ende = false;

    }
  }

  private void BewegeSchlange()
  {

    var schwanz = this.schlange.Last();
    var kopf = this.schlange.First();
    Point2D neuerKopf = new Point2D(0, 0);

    if (moveUp)
    {
      neuerKopf = new Point2D(kopf.X, kopf.Y - 1);

      if (kopf == item)
      {
        schlange.Add(schwanz);
        item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
        score += 1;

        if(GameUpdateTimer.Interval <= 10)
        {
          GameUpdateTimer.Interval -= 5;
        }

      }
    }
    else if (moveRight)
    {
      neuerKopf = new Point2D(kopf.X + 1, kopf.Y);

      if (kopf == item)
      {
        schlange.Add(schwanz);
        item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
        score += 1;
      }
    }
    else if (moveDown)
    {
      neuerKopf = new Point2D(kopf.X, kopf.Y + 1);

      if (kopf == item)
      {
        schlange.Add(schwanz);
        item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
        score += 1;

      }
    }
    else if (moveLeft)
    {
      neuerKopf = new Point2D(kopf.X - 1, kopf.Y);

      if (kopf == item)
      {
        schlange.Add(schwanz);
        item = new Point2D(GetRandomNumber(1, 30), GetRandomNumber(1, 30));
        score += 1;
      }
    }
    // Insert = Einfügen
    // Add Hinzufügen an letzter stelle
    this.schlange.Insert(0, neuerKopf);
    this.schlange.Remove(schwanz);
  }
  protected override void OnArrowDown()
  {
    if(moveUp == true)
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
  private void restset()
  {
    if(enter == true && ende == true)
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
