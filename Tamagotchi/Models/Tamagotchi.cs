using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public int Food { get; set; }
    public int Love { get; set; }
    public int Sleep { get; set; }
    public bool Dead { get; set; }
    public int Age { get; set; }


    public Pet (string name)
    {
      Name = name;
      Food = 50;
      Love = 50;
      Sleep = 50;
      Dead = false;
      Age = 1;
      // _pets.Add(this);
      // Id = _pets.Count;
    }

    public Pet(string name, int id)
    {
      Id = id;
      Name = name;
      Food = 50;
      Love = 50;
      Sleep = 50;
      Dead = false;
      Age = 1;
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

    public override bool Equals(System.Object otherPet)
    {
      if (!(otherPet is Pet))
      {
        return false;
      }
      else
      {
        Pet newPet = (Pet) otherPet;
        bool idEquality = (this.Id == newPet.Id);
        bool nameEquality = (this.Name == newPet.Name);
        return (idEquality && nameEquality);
      }
    }

    public static List<Pet> GetAll()
    {
      List<Pet> allPets = new List<Pet> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM pets;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int petId = rdr.GetInt32(0);
        string petName = rdr.GetString(1);
        // int petFood = rdr.GetInt32(2);
        // int petLove = rdr.GetInt32(3);
        // int petSleep = rdr.GetInt32(4);
        // bool petDead = rdr.GetBoolean(5);
        // int petAge = rdr.GetInt32(6);
        Pet newPet = new Pet(petName, petId);
        allPets.Add(newPet);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPets;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM pets;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public static void PassTime()
    // {
    //   List<Pet> _newPets = new List<Pet> {};
    //   foreach (Pet pet in _pets)
    //   {
    //     if (!pet.Dead)
    //       {
    //       pet.Food -= 5;
    //       pet.Love -= 5;
    //       pet.Sleep -= 5;
    //       pet.Age += 1;
    //       if (pet.Food <= 0 || pet.Love <= 0 || pet.Sleep <= 0 || pet.Age > 100)
    //       {
    //         pet.Dead = true;
    //       }
    //     }
    //   }
    // }

    public static Pet Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM pets WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int petId = 0;
      string petName = "";
      while (rdr.Read())
      {
        petId = rdr.GetInt32(0);
        petName = rdr.GetString(1);
      }
      Pet foundPet= new Pet(petName, petId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundPet;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO pets (name) VALUES (@PetName);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@PetName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}