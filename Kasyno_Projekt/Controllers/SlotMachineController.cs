using Kasyno_Projekt.Classes;
using Kasyno_Projekt.Data;
using Kasyno_Projekt.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMatrix.WebData;

namespace Kasyno_Projekt.Controllers
{

    public class SlotMachineController : Controller
    {
        public SlotMachine SlotMachineGame = new SlotMachine();
        public SlotMachineViewModel SlotMachineViewModel = new SlotMachineViewModel();
        private readonly ApplicationDbContext _context;
        public SlotMachineController(ApplicationDbContext context)
        {
            _context = context;
         
        }
        //SlotMachineViewModel
        public void ChangeUsersChips(string UserId ,int ChipsChange)
        {
            var User = _context.UserBalance.Where(x => x.UserId == UserId).FirstOrDefault(); 
           User.Chips += ChipsChange;
            _context.UserBalance.Update(User);
            _context.SaveChanges(); 
        }


        public int CheckBetSize(SlotMachineViewModel ViewModel, int Bet) 
        {

            if (Bet <= ViewModel.User.Chips && Bet> 0)
            { return Bet; }
            else 
            { return 0; }
        }
        public string GetUserId() 
        {
           return _context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
        }
        public int GetUsersChips(string UserId)
        {
            return _context.UserBalance.Where(x => x.UserId == UserId).FirstOrDefault().Chips;
        }

        public void GetUserAndGame() 
        {
            SlotMachineViewModel.User.UserId = GetUserId();
            SlotMachineViewModel.User.Chips = GetUsersChips(SlotMachineViewModel.User.UserId);
            SlotMachineViewModel.Game = SlotMachineGame;
        }

        [Authorize]
        public IActionResult Index()
        {
            GetUserAndGame();
            SlotMachineViewModel.Game.Losuj();
            return View(SlotMachineViewModel);
        }


        public IActionResult Play(int BetSize)
        {
            GetUserAndGame();
            SlotMachineViewModel.Game.Bet = CheckBetSize(SlotMachineViewModel, BetSize);
            ChangeUsersChips(SlotMachineViewModel.User.UserId, SlotMachineViewModel.Game.Game());
            GetUserAndGame();
            return View("Index",SlotMachineViewModel);
        }
    }
}
