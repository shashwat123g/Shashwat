using Microsoft.AspNetCore.Mvc;
using Shashwat.Models;
using Shashwat.ViewModel;
using System.Diagnostics;

namespace Shashwat.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pies = _pieRepository.AllPies;

           /* PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";*/

            //passing data to view
            return View(pies);

            /* PieListViewModel pieListViewModel = new PieListViewModel();
             pieListViewModel.Pies = pies;
             pieListViewModel.CurrentCategory = "Cheese cakes";
 */
            //passing data to view
            //return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}