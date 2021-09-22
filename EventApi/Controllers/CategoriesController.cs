using Event.Business.Abstract;
using Event.Business.Concete;
using Event.Core.Utilities.Mapper;
using Event.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Event.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService { get; set; }
        private IAutoMapper _autoMapper { get; set; }
        private ILookUpService<Category> _lookUpService { get; set; }

        public CategoriesController(ICategoryService categoryService, IAutoMapper autoMapper, ILookUpService<Category> lookUpService)
        {
            _categoryService = categoryService;
            _autoMapper = autoMapper;
            _lookUpService = lookUpService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetCategoryLookUp()
        {
            var result = _categoryService.GetAll();
            var lookUps = await _lookUpService.GetLookUp(null, "Id", "Title");

            return Ok(lookUps);
        }

        // Post: api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            var result = await _categoryService.AddAsync(category);

            return Created(String.Empty, result);
        }

    }
}
