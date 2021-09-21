using Event.Business.Abstract;
using Event.Core.Utilities.Mapper;
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
    public class EventsController : ControllerBase
    {

        public IEventService _eventService { get; set; }
        public IAutoMapper _autoMapper { get; set; }

        public EventsController(IEventService eventService, IAutoMapper autoMapper)
        {
            _eventService = eventService;
            _autoMapper = autoMapper;

        }


        // GET: api/<EventsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _eventService.GetAll());
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public async Task<IActionResult> Post(Entities.Concrete.Event Entity)
        {
            var result = _eventService.AddAsync(Entity);

            return Created(string.Empty, result);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
