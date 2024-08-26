using LibraryCoreApi.DAL.Interfaces;
using LibraryCoreApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCoreApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        IRepository<Publisher> _publisherRepo;

        public PublisherController(IRepository<Publisher> repository)
        {
            _publisherRepo = repository;
        }

        [HttpGet, Route("GetPublishers")]
        public async Task<IActionResult> Get()
        {
            var publisher = await _publisherRepo.Get();
            return Ok(publisher);
        }

        [HttpGet, Route("GetPublisher/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var publisher = await _publisherRepo.Get(id);
            return Ok(publisher);
        }

        [HttpPost, Route("InsertPublisher")]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            var data = await _publisherRepo.Post(publisher);
            if (data != null)
            {
                return Ok(publisher);
            }
            return Content("Publisher Already Exists!!!");
        }

        [HttpDelete, Route("DeletePublisher/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _publisherRepo.Delete(id);
            return Ok(data);
        }

        [HttpPut, Route("UpdatePublisher/{id}")]
        public async Task<IActionResult> Put(Publisher publisher, int id)
        {
            var data = await _publisherRepo.Put(id, publisher);
            return Ok(data);
        }
    }
}
