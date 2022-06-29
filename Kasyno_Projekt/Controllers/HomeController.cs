using Kasyno_Projekt.Data;
using Kasyno_Projekt.Models;
using Kasyno_Projekt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kasyno_Projekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public UsersRanking GetUserRanking() 
        {
            var Users = _context.Users;
            UsersRanking ranking = new UsersRanking();
            foreach(var user in Users) 
            {
                var UserDetails = new DisplayUser();
                UserDetails.UserName = user.UserName;
                UserDetails.ChipsAmmount = _context.UserBalance.Where(x => x.UserId == user.Id).FirstOrDefault().Chips;
                ranking.RankingList.Add(UserDetails);
            }

            ranking.RankingList = ranking.RankingList.OrderByDescending(x => x.ChipsAmmount).ToList();

            //ranking.RankingList.OrderByDescending(x => x.ChipsAmmount);
            return ranking;
        }



        public IActionResult Index()
        {
           
         
            return View(GetUserRanking());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}