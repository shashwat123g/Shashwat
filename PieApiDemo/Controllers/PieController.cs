using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PieApiDemo.Models;

namespace PieApiDemo.Controllers
{
    [ApiController]
    [Route("Pie")]
    public class PieController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieRepository _pieRepository;
        // private readonly IMapper mapper;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;


        }
        [HttpGet]
        [Route("AllPie")]
        public IActionResult AllPie()
        {
            try
            {

                var pies = this._pieRepository.AllPies;

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("FruitPie")]
        public IActionResult FruitPies()
        {
            try
            {

                var pies = this._pieRepository.FruitPies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("CheesePie")]
        public IActionResult CheesePie()
        {
            try
            {

                var pies = this._pieRepository.CheesPies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("SeasonPie")]
        public IActionResult SeasonPie()
        {
            try
            {

                var pies = _pieRepository.SeasonPies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Pie pie)
        {
            try
            {
                var insert = _pieRepository.Insert(pie);
                return Ok(insert);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Pie pie)
        {
            try
            {
                var insert = this._pieRepository.Update(pie);
                return Ok(pie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var insert = this._pieRepository.Delete(id);
                return Ok(insert);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var AllCategories = this._categoryRepository.AllCategories;
                return Ok(AllCategories);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        /*[HttpGet("{id}", Name = "GetCategory")]*/
        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var category = this._categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == id);
                if (category == null)
                    return NotFound("Category Not found For this ID");
                return Ok(category);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {

            try
            {
                var insertCategory = this
                                ._categoryRepository
                                .InsertCategory(category);
                return Ok(InsertCategory);
                /*return CreatedAtRoute("GetCategory", new { id = InsertCategory.CategoryId }, InsertCategory);*/
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                var UpdatedCategory = this
                                ._categoryRepository
                                .UpdateCategory(category);
                return Ok(UpdatedCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("DeleteCategory")]
         public IActionResult DeleteCategory(int categoryID)
         {
            try
            {
                var category = this._categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == categoryID);
                if (category == null)
                {
                    return BadRequest("Category not found, try some other valid id");
                }
                var DeletedCategory = this
                    ._categoryRepository
                    .DeleteCategory(categoryID);
                return Ok(DeletedCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }
        [HttpGet]
        [Route("GetPieById")]
        public IActionResult GetPieById(int id)
        {
            try
            {
                var pie = _pieRepository.GetPieById(id);
                return Ok(pie);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "ServerError Or Site Under Maintanance");
            }

        }


    }
}

