using Kasyno_Projekt.Classes;
using Kasyno_Projekt.Models;

namespace Kasyno_Projekt.ViewModels
{
    public class HorseRacingViewModel
    {
        public HorseRacing Game;
        public UserBalance User;
       
        public HorseRacingViewModel() 
        {
            Game = new HorseRacing();
            User = new UserBalance();
        }

    }
}
