using Kasyno_Projekt.Classes;

namespace Kasyno_Projekt.Classes
{

    public class Horse 
    {
        public string Id { get; set; }
        public int Speed { get; set; }
    
        public Horse(string Id , int Speed)
        {
            this.Id = Id;
            this.Speed = Speed;
        }

    }
    public class HorseRacing
    {
        public Random rnd = new Random();
        public List<Horse> Horses = new List<Horse>();
        public int Bet = 5;
        public string UsersHorse="_";

        public void RaceHorses()
        {
            var Winner = rnd.Next(1, 11);

            if (Winner < 6) 
            {
                var HorseToAdd = new Horse("R", rnd.Next(1, 6));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("B", rnd.Next(HorseToAdd.Speed + 1, 7));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("G", rnd.Next(HorseToAdd.Speed + 1, 8));
                Horses.Add(HorseToAdd);
                Horses=Horses.OrderBy(x => x.Id).ToList();

            }
            if (Winner >= 6 && Winner < 10)
            {
                var HorseToAdd = new Horse("B", rnd.Next(1, 6));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("R", rnd.Next(HorseToAdd.Speed + 1, 7));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("G", rnd.Next(HorseToAdd.Speed + 1, 8));
                Horses.Add(HorseToAdd);
                Horses = Horses.OrderBy(x => x.Id).ToList();
            }
            if (Winner == 10)
            {
                var HorseToAdd = new Horse("G", rnd.Next(1, 6));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("R", rnd.Next(HorseToAdd.Speed + 1, 7));
                Horses.Add(HorseToAdd);

                HorseToAdd = new Horse("B", rnd.Next(HorseToAdd.Speed + 1, 8));
                Horses.Add(HorseToAdd);
                Horses = Horses.OrderBy(x => x.Id).ToList();
            }
        }
      
        public string GetWinner()
        {
            if(Horses.OrderBy(x => x.Speed).FirstOrDefault().Id is not null)
            { return Horses.OrderBy(x => x.Speed).FirstOrDefault().Id; }
            else 
            { return "_"; }
        }


       public int Game_Result()
        {
            if(GetWinner()==UsersHorse|| UsersHorse=="_") 
            {
                if (UsersHorse == "_") { return 0; }
                if (UsersHorse == "R") { return Bet * 2; }
                if (UsersHorse == "B") { return Bet * 3; }
                if (UsersHorse == "G") { return Bet * 10; }
            }
            return -Bet;
        }


    }
}
