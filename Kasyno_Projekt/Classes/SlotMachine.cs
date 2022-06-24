using System;

namespace Kasyno_Projekt.Classes
{
    public class SlotMachine
    {
        public string[] Slots = { "🍒", "💲", "🔔", "🍇", "👌", "𝟳" };
        private Random Rnd = new Random();
        public int Bet=5;
        public string CurrentSlots = "___";
        public string[] DisplaySlots = new string[3];
        public SlotMachine()
        {
        }

        public void Losuj()
        {
            CurrentSlots = "";
            for (int i = 0; i < 3; i++)
            {
                DisplaySlots[i] = Slots[Rnd.Next(0, Slots.Length)];
                CurrentSlots += DisplaySlots[i];
            }
        }

        public int Game_Result()
        {
            if (CurrentSlots == "👌👌👌")
            {
                return Bet * 10;
            }
            if (CurrentSlots == "🍇🍇🍇")
            {
                return Bet * 15;
            }
            if (CurrentSlots == "🔔🔔🔔")
            {
                return Bet * 20;
            }
            if (CurrentSlots == "💲💲💲")
            {
                return Bet * 30;
            }
            if (CurrentSlots == "🍒🍒🍒")
            {
                return Bet * 50;
            }
            if (CurrentSlots == "𝟳𝟳𝟳")
            {
                return Bet * 100;
            }
            if (CurrentSlots.Contains("🍒") && !CurrentSlots.Contains("🍒🍒") && CurrentSlots != "🍒🍒🍒")
            {
                return Bet * 2;
            }
            if (CurrentSlots.Contains("🍒🍒") || (CurrentSlots.StartsWith("🍒") && CurrentSlots.EndsWith("🍒")) && CurrentSlots != "🍒🍒🍒")
            {
                return Bet * 4;
            }


            return -Bet;
        }


        public int Game()
        {
            Losuj();

            return Game_Result();
        }

    }
}
