using System.Collections.Generic;

namespace Tamagotchis.Models
{

  public class Tamagotchi
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Attention { get; set; }
    public int Rest { get; set; }
    public int Id { get; }
    public bool Alive { get; set; }
    
    private static List<Tamagotchi> _instances = new List<Tamagotchi> {};

    public Tamagotchi(string name)
    {
      Name = name;
      Food = 100;
      Attention = 100;
      Rest = 100;
      Alive = true;
      _instances.Add(this);
      Id = _instances.Count;
    }
    //PassTime
    public static void PassTime()
    {
      foreach (Tamagotchi element in _instances)
      {
        element.Food = element.Food - 5;
        element.Rest = element.Rest - 5;
        element.Attention = element.Attention - 5;
        if (element.Food <= 0)
        {
          element.Alive = false;
        }

      }
    }
    public void GiveFood()
    {
      Food = Food + 20;
      Rest = Rest - 15;
      PassTime();
    }
      public void AttentionProvide()
    {
      Attention = Attention + 20;
      Food = Food - 15;
      PassTime();
    }
      public void SleepNow()
    {
      Rest = 100;
      Food = Food - 50;
      Attention = Attention -50;
      PassTime();
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }
    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public string AliveOrDead()
    {
      if (Alive)
      {
        return "Alive";
      }
      else
      {
        return "ded";
      }
    }
    //     public static Item Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }
  }
}