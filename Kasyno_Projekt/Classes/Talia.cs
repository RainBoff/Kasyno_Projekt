using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasyno_Projekt.Classes
{
    public class Talia
    {
        static string[] KolorArray = { "♥", "♦", "♠", "♣" };
        public List<Karta> Karty = new List<Karta>();

        public Talia()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Karty.Add(new Karta(j, KolorArray[i]));
                }
            }
        }
        public void Tasuj()
        {
            for (int i = 0; i < 10001; i++)
            {
                var rnd = new Random();
                var TasowanaKarta = Karty[rnd.Next(0, Karty.Count())];
                Karty.Remove(TasowanaKarta);
                Karty.Add(TasowanaKarta);

            }
        }
    }
}
