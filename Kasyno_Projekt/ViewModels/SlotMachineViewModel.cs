using Kasyno_Projekt.Classes;
using Kasyno_Projekt.Models;

namespace Kasyno_Projekt.ViewModels
{
    public class SlotMachineViewModel
    {
        public SlotMachine Game;
        public UserBalance User;

        public SlotMachineViewModel()
        {
            Game = new SlotMachine();
            User = new UserBalance();
        }
    }
}
