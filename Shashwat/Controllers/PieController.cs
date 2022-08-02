
using Microsoft.AspNetCore.Mvc;
using Shashwat.Models;
using Shashwat.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shashwat.Controllers
{
    public class PieController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICategoryRepository categoryRepository;
        private readonly IPieRepository _pieRepository;
        private readonly AppDbContext appDbContext;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, AppDbContext appDbContext)
        {

            categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
            this.appDbContext = appDbContext;
        }

        public async Task<ViewResult> List(int id)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/AllPie"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }

            }
            if (id > 0)
            {
                return View(pies.Where(s => s.CategoryId == id));

            }


            /* PieListViewModel pieListViewModel = new PieListViewModel();
             pieListViewModel.Pies = pies;
             pieListViewModel.CurrentCategory = "Cheese Cake";*/

            // Passing data to view
            return View(pies);
            //passing data to view

        }
        /* public IActionResult listMini(int categoryId)
         {
             var pies = _pieRepository.AllPies;
             var piesmini = mapper.Map<PieMini[]>(pies);
             return View(piesmini);
         }*/

        public async Task<ViewResult> FruitPies()
        {
            IEnumerable<Pie> Pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/FruitPie"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
                //got the pie data
                var pies = _pieRepository.FruitPies();

                /* PieListViewModel pieListViewModel = new PieListViewModel();
                 pieListViewModel.Pies = pies;
                 pieListViewModel.CurrentCategory = "Cheese cakes";
     */
                //passing data to view
                return View(pies);
            }
        }
        public async Task<ViewResult> CheesPies()
        {
            IEnumerable<Pie> Pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/CheesPie"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
                //got the pie data
                var pies = _pieRepository.CheesPies();



                //passing data to view
                return View(pies);
            }
        }
        public async Task<ViewResult> SeasonPies()
        {
            IEnumerable<Pie> Pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/SeasonPie"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
                //got the pie data
                var pies = _pieRepository.SeasonPies();

                /* PieListViewModel pieListViewModel = new PieListViewModel();
                 pieListViewModel.Pies = pies;
                 pieListViewModel.CurrentCategory = "Cheese cakes";
     */
                //passing data to view
                return View(pies);
            }
        }
        public async Task<ViewResult> Details(int id)
        {
            var pies = new Pie();

            /*IEnumerable<Pie> Pies = new List<Pie>();*/
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/GetPieById?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject/*<IEnumerable*/<Pie>(apiResponse);
                }
                //got the pie data
                //var pies = _pieRepository.AllPies.FirstOrDefault(pies => pies.PieId == id);

                /*PieListViewModel pieListViewModel = new PieListViewModel();
                pieListViewModel.Pies = pies;
                pieListViewModel.CurrentCategory = "Cheese cakes";*/

                //passing data to view
                return View(pies);
            }
        }
        /*public IActionResult Create()
        { return View(); }*/
        public ViewResult Create()
        {
            //application - you have to change this one to get it from API
            /*var categories = categoryRepository.AllCategories;

            var categoriesItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoriesItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }
*/
            // var pie = new Pie();
            /*ViewBag.Categories = categoriesItems;*/
            return View();

        }
        public async Task<IActionResult> CreatePie(Pie pie)
        {
            /* _pieRepository.CreatePie(pie);
             return RedirectToAction("List");*/
            /*IEnumerable<Pie> pies = new List<Pie>();*/
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7212/Pie/Insert", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult AddToCart(int id)
        {
            var pies = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == id);

            /*string cartid1 = httpContextAccessor.HttpContext.User.Identity.Name;*/

            /*
                        var order = _pieRepository.AllOrder.SingleOrDefault(
                        c => c.CartID == cartid1
                        && c.PieId == id);*/
            Order order = new Order();



            order = new Order();
            order.PieId = pies.PieId;
            order.PieName = pies.Name;
            order.PiePrice = pies.Price;
            order.CartID = "shashwat@globallogic.com";
            order.Quantity = 1;
            int result = _pieRepository.CreateOrder(order);
            return RedirectToAction("List");
            /*
            else
            {
                order.Quantity++;
                int result = _pieRepository.UpdateOrder(order);
                return RedirectToAction("List");


            }*/
        }
        public IActionResult ViewCart()
        {
            /*string Userid = httpContextAccessor.HttpContext.User.Identity.Name;
*/


            var cart = appDbContext.order;/*.Where(x => x.CartID );
            if (//Userid == "admin@gmail.com")
            {
                cart = appDbContext.order;
            }

            ViewBag.Uid = Userid;*/
            return View(cart);
        }

        public async Task<IActionResult> UpdatePie(Pie pie)
        {
            /*pieRepository.UpdatePie(pie);
            return RedirectToAction("AllCategory");*/
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7212/Pie/Update", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var pie = new Pie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7212/Pie/Delete?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pie = JsonConvert.DeserializeObject<Pie>(apiResponse);
                }
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var pie = new Pie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/Update" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pie = JsonConvert.DeserializeObject<Pie>(apiResponse);
                }
            }
            return View(pie);
        }
        public async Task<IActionResult> Update(Pie pie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7212/Pie/AllPie", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllPies");
        }
    }      
}
        
    

