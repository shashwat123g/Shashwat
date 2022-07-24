using Microsoft.AspNetCore.Mvc;
using Shashwat.Models;
using Shashwat.ViewModel;

namespace Shashwat.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult List()
        {
            //got the pie data
            var pies = _pieRepository.AllPies;

            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";

            //passing data to view
            return View(pieListViewModel);
        }
        public ViewResult PieWeak()
        {
            //got the pie data
            var pies = _pieRepository.AllPies;

           /* PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";
*/
            //passing data to view
            return View(pies);
        }
        public IActionResult Categories()
        {
            //got the pie data
            var pies = _pieRepository.AllPies;

            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";

            //passing data to view
            return View(pieListViewModel);
        }
        public ViewResult Details(int id)
        {
            //got the pie data
            var pies = _pieRepository.AllPies.FirstOrDefault(pies=>pies.PieId==id);

            /*PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes";*/

            //passing data to view
            return View(pies);
        }


    }
}
