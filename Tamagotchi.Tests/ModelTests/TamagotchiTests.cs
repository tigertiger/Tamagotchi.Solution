using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Tamagotchi.Models;
using System;

namespace Tamagotchi.Tests
{
  [TestClass]
  public class PetTests : IDisposable
  {

    public void Dispose()
    {
      Pet.ClearAll();
    }

    public PetTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=tamagotchi;";
    }

    // [TestMethod]
    // public void PetConstructor_CreatesInstanceOfPet_Pet()
    // {
    //   Pet newPet = new Pet("George");
    //   Assert.AreEqual(typeof(Pet), newPet.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   string name = "George";
    //   Pet newPet = new Pet(name);
    //   string result = newPet.Name;
    //   Assert.AreEqual(name, result);
    //   Assert.AreEqual(50, newPet.Food);
    //   Assert.AreEqual(50, newPet.Love);
    //   Assert.AreEqual(50, newPet.Sleep);
    // }

    // [TestMethod]
    // public void SetName_SetName_String()
    // {
    //   string name = "George";
    //   Pet newPet = new Pet(name);
    //   string updatedName = "Jane";
    //   newPet.Name = updatedName;
    //   string result = newPet.Name;
    //   Assert.AreEqual(updatedName, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_PetList()
    {
      List<Pet> newList = new List<Pet> { };
      List<Pet> result = Pet.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_PetList()
    {
      Pet testPet = new Pet("Biddy");

      testPet.Save();
      List<Pet> result = Pet.GetAll();
      List<Pet> testList = new List<Pet>{testPet};

      CollectionAssert.AreEqual(testList, result);
    }
    
    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Pet()
    {
      // Arrange, Act
      Pet firstPet = new Pet("Biddy");
      Pet secondPet = new Pet("Biddy");

      // Assert
      Assert.AreEqual(firstPet, secondPet);
    }

    // [TestMethod]
    // public void GetAll_ReturnsPets_PetList()
    // {
    //   string name01 = "George";
    //   string name02 = "Jane";
    //   Pet newPet1 = new Pet(name01);
    //   Pet newPet2 = new Pet(name02);
    //   List<Pet> newList = new List<Pet> { newPet1, newPet2 };
    //   List<Pet> result = Pet.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void GetId_PetsInstantiateWithAnIdAndGetReturns_Int()
    // {
    //   string name = "George";
    //   Pet newPet = new Pet(name);
    //   int result = newPet.Id;
    //   Assert.AreEqual(1, result);
    // }

    // [TestMethod]
    // public void Find_ReturnsCorrectPet_Pet()
    // {
    //   string name01 = "George";
    //   string name02 = "Jane";
    //   Pet newPet1 = new Pet(name01);
    //   Pet newPet2 = new Pet(name02);
    //   Pet result = Pet.Find(2);
    //   Assert.AreEqual(newPet2, result);
    // }

    // [TestMethod]
    // public void FeedPet_FeedsPet_Int()
    // {
    //   Pet newPet = new Pet("George");
    //   newPet.FeedPet();
    //   Assert.AreEqual(60, newPet.Food);
    // }
    // [TestMethod]
    // public void LovePet_LovesPet_Int()
    // {
    //   Pet newPet = new Pet("George");
    //   newPet.LovePet();
    //   Assert.AreEqual(60, newPet.Love);
    // }
    
    // [TestMethod]
    // public void Rest_RestsPet_Int()
    // {
    //   Pet newPet = new Pet("George");
    //   newPet.RestPet();
    //   Assert.AreEqual(60, newPet.Sleep);
    // }
    
    // [TestMethod]
    // public void PassTime_DecrementsPetStats_Int()
    // {
    //   Pet newPet1 = new Pet("George");
    //   Pet newPet2 = new Pet("Willard");
    //   Pet.PassTime();
    //   Assert.AreEqual(45, newPet1.Food);
    //   Assert.AreEqual(45, newPet1.Love);
    //   Assert.AreEqual(45, newPet1.Sleep);
    //   Assert.AreEqual(45, newPet2.Food);
    //   Assert.AreEqual(45, newPet2.Love);
    //   Assert.AreEqual(45, newPet2.Sleep);
    // }

    // [TestMethod]
    // public void PassTime_RemovesDeadPet_PetList()
    // {
    //   Pet newPet1 = new Pet("George");
    //   Pet newPet2 = new Pet("Willard");
    //   Pet newPet3 = new Pet("Jane");
    //   Pet newPet4 = new Pet("Bri");
    //   newPet1.Food = 5;
    //   newPet2.Love = 5;
    //   newPet3.Sleep = 5;
    //   Pet.PassTime();
    //   List<Pet> petList = Pet.GetAll();
    //   Assert.AreEqual(1, petList.Count);

    // }
  }
}