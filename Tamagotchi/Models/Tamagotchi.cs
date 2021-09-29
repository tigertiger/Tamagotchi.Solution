using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Love { get; set; }
    public int Sleep { get; set; }
    public int Id { get; }
    private static List<Pet> _pets = new List<Pet> {};

    public Pet (string name)
    {
      Name = name;
      Food = 50;
      Love = 50;
      Sleep = 50;
      _pets.Add(this);
      Id = _pets.Count;
    }

    public static List<Pet> GetAll()
    {
      return _pets;
    }

    public static void ClearAll()
    {
      _pets.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _pets[searchId-1];
    }

  }
}