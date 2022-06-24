using System.ComponentModel.DataAnnotations.Schema;

namespace Kasyno_Projekt.Models
{
    public class UserBalance
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Chips { get; set; }

    }
}
