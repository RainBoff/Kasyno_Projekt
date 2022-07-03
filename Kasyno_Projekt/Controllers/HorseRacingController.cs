using Kasyno_Projekt.Classes;
using Kasyno_Projekt.Data;
using Kasyno_Projekt.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kasyno_Projekt.Controllers
{
    public class HorseRacingController : Controller
    {
        public HorseRacing HorseRacingGame = new HorseRacing();
        public HorseRacingViewModel HorseRacingViewModel = new HorseRacingViewModel();
        private readonly ApplicationDbContext _context;

        public HorseRacingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetUserId()
        {
            return _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
        }
        public int GetUsersChips(string UserId)
        {
            return _context.UserBalance.Where(x => x.UserId == UserId).FirstOrDefault().Chips;
        }
        public void ChangeUsersChips(string UserId, int ChipsChange)
        {
            var User = _context.UserBalance.Where(x => x.UserId == UserId).FirstOrDefault();
            User.Chips += ChipsChange;
            _context.UserBalance.Update(User);
            _context.SaveChanges();
        }
        public void GetUserAndGame()
        {
            HorseRacingViewModel.User.UserId = GetUserId();
            HorseRacingViewModel.User.Chips = GetUsersChips(HorseRacingViewModel.User.UserId);
            HorseRacingViewModel.Game = HorseRacingGame;
        }

        public int CheckBetSize(HorseRacingViewModel ViewModel, int Bet)
        {

            if (Bet <= ViewModel.User.Chips && Bet > 0)
            { return Bet; }
            else
            { return 0; }
        }


        public IActionResult Index()
        {
            GetUserAndGame();
            HorseRacingViewModel.Game.RaceHorses();
            return View(HorseRacingViewModel);
        }

        public IActionResult Race()
        {
            GetUserAndGame();
            
            HorseRacingViewModel.Game.RaceHorses();
            ChangeUsersChips(HorseRacingViewModel.User.UserId, HorseRacingViewModel.Game.Game_Result());
            GetUserAndGame();
            return View("Index", HorseRacingViewModel);
        }

        public IActionResult BetBlue(int BetSize)
        {
            GetUserAndGame();
            HorseRacingViewModel.Game.Bet = CheckBetSize(HorseRacingViewModel, BetSize);
            HorseRacingViewModel.Game.UsersHorse = "B";
            HorseRacingViewModel.Game.RaceHorses();
            ChangeUsersChips(HorseRacingViewModel.User.UserId, HorseRacingViewModel.Game.Game_Result());
            GetUserAndGame();
            return View("Index", HorseRacingViewModel);
        }
        public IActionResult BetGreen(int BetSize)
        {
            GetUserAndGame();
            HorseRacingViewModel.Game.Bet = CheckBetSize(HorseRacingViewModel, BetSize);
            HorseRacingViewModel.Game.UsersHorse = "G";
            HorseRacingViewModel.Game.RaceHorses();
            ChangeUsersChips(HorseRacingViewModel.User.UserId, HorseRacingViewModel.Game.Game_Result());
            GetUserAndGame();
            return View("Index", HorseRacingViewModel);
        }
        public IActionResult BetRed(int BetSize)
        {
            GetUserAndGame();
            HorseRacingViewModel.Game.Bet = CheckBetSize(HorseRacingViewModel, BetSize);
            HorseRacingViewModel.Game.UsersHorse = "R";
            HorseRacingViewModel.Game.RaceHorses();
            ChangeUsersChips(HorseRacingViewModel.User.UserId, HorseRacingViewModel.Game.Game_Result());
            GetUserAndGame();
            return View("Index", HorseRacingViewModel);
        }


    }
}
