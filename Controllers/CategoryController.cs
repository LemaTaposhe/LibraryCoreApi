using LibraryCoreApi.DAL.Interfaces;
using LibraryCoreApi.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCoreApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Category")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CategoryController : ControllerBase
    {
        IRepository<Category> _categoryRepo;

        public CategoryController(IRepository<Category> repository)
        {
            _categoryRepo = repository;
        }

        [HttpGet, Route("GetCategories")]
        public async Task<IActionResult> Get()
        {
            var category = await _categoryRepo.Get();
            return Ok(category);
        }

        [HttpGet, Route("GetCategory/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepo.Get(id);
            return Ok(category);
        }

        [HttpPost, Route("InsertCategory")]
        public async Task<IActionResult> Post(Category category)
        {
            var data = await _categoryRepo.Post(category);
            if (data != null)
            {
                return Ok(category);
            }
            return Content("Category Already Exists!!!");
        }

        [HttpDelete, Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoryRepo.Delete(id);
            return Ok(data);
        }

        [HttpPut, Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Put(Category category, int id)
        {
            var data = await _categoryRepo.Put(id, category);
            return Ok(data);
        }
    }
}
