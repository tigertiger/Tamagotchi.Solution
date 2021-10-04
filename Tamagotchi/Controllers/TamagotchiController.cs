using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
  public class PetsController : Controller
  {

    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }

    [HttpGet("/pets/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/pets")]
    public ActionResult Create(string name, int food, int love, int sleep, bool dead, int age, int id)
    {
      Pet myPet = new Pet(name, food, love, sleep, dead, age, id);
      myPet.Save();
      return RedirectToAction("Index");
    }

    // [HttpPost("/pets/wait")]
    // public ActionResult Wait()
    // {
    //   Pet.PassTime();
    //   return RedirectToAction("Index");
    // }

    [HttpPost("/pets/{id}/feed")]
    public ActionResult Feed(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.FeedPet();
      return View("Show", foundPet);
    }

    [HttpPost("/pets/{id}/love")]
    public ActionResult Love(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.LovePet();
      return View("Show", foundPet);
    }

    [HttpPost("/pets/{id}/rest")]
    public ActionResult Rest(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.RestPet();
      return View("Show", foundPet);
    }

    [HttpPost("/pets/delete")]
    public ActionResult DeleteAll()
    {
      Pet.ClearAll();
      return View();
    }

    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Pet foundPet = Pet.Find(id);
      return View(foundPet);
    }

  }
}