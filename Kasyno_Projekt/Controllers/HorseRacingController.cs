using Kasyno_Projekt.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Kasyno_Projekt.Controllers
{
    public class HorseRacingController : Controller
    {
        public HorseRacing HorseRacingGame = new HorseRacing();

        public IActionResult Index()
        {
            HorseRacingGame.RaceHorses();
            return View(HorseRacingGame);
        }
    }
}
