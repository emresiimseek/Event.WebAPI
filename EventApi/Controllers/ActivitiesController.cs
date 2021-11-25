using AutoMapper;
using Event.Business.Abstract;
using Event.Business.Mappers;
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
        public IUserService _userService { get; set; }
        public IAutoMapper _autoMapper { get; set; }


        public ActivitiesController(IEventService eventService, IAutoMapper autoMapper, IUserService userService)
        {
            _eventService = eventService;
            _autoMapper = autoMapper;
            _userService = userService;

        }

        // GET: api/<ActivitiesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _eventService.GetAll());
        }

        // GET: api/<ActivitiesController>
        [HttpPost("GetEvent")]
        public async Task<IActionResult> GetById(User_Activity value)
        {
            return Ok(await _eventService.GetEventById(value.ActivityId, value.UserId));
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Post(ActivityDto Entity)
        {
            var mapped = _autoMapper.MapToSameType<ActivityDto, Activity>(Entity);
            var result = await _eventService.AddAsync(mapped);
            var serviceResponse = _autoMapper.MapToSameType<Activity, ActivityDto>(result);

            return Created(string.Empty, serviceResponse);
        }



        [HttpGet("GetAllFriendsActivities/{id}")]
        public async Task<IActionResult> GetAllFriendsActivities(int id)
        {
            var result = await _eventService.GetAllFriendsActivities(id);
            return Ok(result);

        }

        [HttpPost("LikeActivity")]
        public async Task<IActionResult> Like(Activity_Like Like)
        {
            var result = await _eventService.LikeActivity(Like);
            return Created(string.Empty, result);

        }

        [HttpPost("UnlikeActivity")]
        public async Task<IActionResult> UnLike(Activity_Like Like)
        {
             _eventService.UnLikeActivity(Like);
            return NoContent();

        }

    }
}

