using Microsoft.AspNetCore.Mvc;
using Kasyno_Projekt.Classes;


namespace Kasyno_Projekt.Controllers
{
    public class BlackJackController : Controller
    {
        static BlackJack BlackJack = new BlackJack();
        public IActionResult Index()
        {
            BlackJack.Rozdanie();
            BlackJack.LiczPunkty();
            //  BlackJackGame.GameOutcome();
            return View(BlackJack);
        }

        public IActionResult Hit()
        {
            BlackJack.PlayerHit();
            return View("Index", BlackJack);
        }

        public IActionResult Stay()
        {
            BlackJack.PlayerStays();
            return View("Index", BlackJack);
        }

        public IActionResult DoubleDown()
        {
            BlackJack.PlayerDoubleDown();
            return View("Index", BlackJack);
        }
        public IActionResult Split()
        {
            BlackJack.PlayerSplit();
            return View("Index", BlackJack);
        }

        public IActionResult ChangeHand()
        {
            BlackJack.ChangeHand();
            return View("Index", BlackJack);
        }

        public IActionResult BetRise()
        {
            BlackJack.RiseBet();
            return View("Index", BlackJack);
        }

        public IActionResult BetLower()
        {
            BlackJack.LowerBet();
            return View("Index", BlackJack);
        }

    }
}
