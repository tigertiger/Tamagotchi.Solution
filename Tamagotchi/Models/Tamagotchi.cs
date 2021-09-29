using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Love { get; set; }
    public int Sleep { get; set; }
    public bool Dead { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }

    private static List<Pet> _pets = new List<Pet> {};

    public Pet (string name)
    {
      Name = name;
      Food = 50;
      Love = 50;
      Sleep = 50;
      Dead = false;
      Age = 1;
      _pets.Add(this);
      Id = _pets.Count;
    }

    public void FeedPet()
    {
      if ((this.Food + 10) > 100)
      {
        this.Food = 100;
      }
      else
      {
        this.Food += 10;
      }
    }

    public void LovePet()
    {
      if ((this.Love + 10) > 100)
      {
        this.Love = 100;
      }
      else
      {
        this.Love += 10;
      }
    }

    public void RestPet()
    {
      if ((this.Sleep + 10) > 100)
      {
        this.Sleep = 100;
      }
      else
      {
        this.Sleep += 10;
      }
    }

    public static List<Pet> GetAll()
    {
      return _pets;
    }

    public static void ClearAll()
    {
      _pets.Clear();
    }

    public static void PassTime()
    {
      List<Pet> _newPets = new List<Pet> {};
      foreach (Pet pet in _pets)
      {
        if (!pet.Dead)
          {
          pet.Food -= 5;
          pet.Love -= 5;
          pet.Sleep -= 5;
          pet.Age += 1;
          if (pet.Food <= 0 || pet.Love <= 0 || pet.Sleep <= 0 || pet.Age > 100)
          {
            pet.Dead = true;
          }
        }
      }
    }

    public static Pet Find(int searchId)
    {
      return _pets[searchId-1];
    }

  }
}