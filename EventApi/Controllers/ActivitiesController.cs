using Event.Business.Abstract;
using Event.Core.Utilities.Mapper;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using EventApi.Filters.FluentValidation;
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
    public class ActivitiesController : ControllerBase
    {
        public IEventService _eventService { get; set; }
        public IAutoMapper _autoMapper { get; set; }

        public ActivitiesController(IEventService eventService, IAutoMapper autoMapper)
        {
            _eventService = eventService;
            _autoMapper = autoMapper;

        }

        // GET: api/<ActivitiesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _eventService.GetAll());
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Post(ActivityDto Entity)
        {
            var mapped = _autoMapper.MapToSameType<ActivityDto, Activity>(Entity);
            var result = await _eventService.AddAsync(mapped);
            var serviceResponse = _autoMapper.MapToSameType<IServiceResponseModel<Activity>, IServiceResponseDto<ActivityDto>>(result);

            return Created(string.Empty, serviceResponse);
        }

    }
}
