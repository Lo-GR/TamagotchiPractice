using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tamagotchis.Models;


namespace Tamagotchis.Controllers
{
  public class TamagotchisController : Controller
  {
    [HttpGet("/tamagotchis")]
    public ActionResult Index()
    {
      List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
      return View(allTamagotchis);
    }
    [HttpGet("/tamagotchis/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/tamagotchis")]
    public ActionResult Create(string name)
    {
      Tamagotchi newTamagotchi = new Tamagotchi(name);
      return RedirectToAction("Index");
    }
    [HttpGet("/tamagotchis/{id}")]
    public ActionResult Show(int id)
    {
      Tamagotchi foundTam = Tamagotchi.Find(id);
      return View(foundTam);
    }
    [HttpPost("/tamagotchis/passtime")]
    public ActionResult Update()
    {
      Tamagotchi.PassTime();
      return RedirectToAction("Index");
    }
    [HttpPost("/tamagotchis/foodgive/{id}")]
    public ActionResult UpdateFood(int id)
    {
      Tamagotchi hungryTam = Tamagotchi.Find(id);
      hungryTam.GiveFood();
      return RedirectToAction("Index");
    }
        [HttpPost("/tamagotchis/sleepnow/{id}")]
    public ActionResult UpdateSleep(int id)
    {
      Tamagotchi sleepyTam = Tamagotchi.Find(id);
      sleepyTam.SleepNow();
      return RedirectToAction("Index");
    }
    [HttpPost("/tamagotchis/attentionprovide/{id}")]
    public ActionResult UpdateAttention(int id)
    {
      Tamagotchi needyTam = Tamagotchi.Find(id);
      needyTam.AttentionProvide();
      return RedirectToAction("Index");
    }
  }
}