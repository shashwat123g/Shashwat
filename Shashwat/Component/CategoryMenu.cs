using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shashwat.Models;

namespace Shashwat.Component
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Fetching the data from the category api

            IEnumerable<Category> category = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7212/Pie/GetAllCategories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<IEnumerable<Category>>(apiResponse);
                }
            }
            return View(category);


        }

    }
}
