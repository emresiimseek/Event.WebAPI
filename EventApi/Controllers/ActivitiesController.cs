using AutoMapper;
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

        [HttpPost("getusersactivities/{id}")]
        public async Task<IActionResult> GetActivitiesByUser(int id)
        {
            var result = await _userService.GetUserWithActivities(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Activity, ActivityDto>();

                cfg.CreateMap<User_Activity, UserActivityDto>()
                .ForMember(dest => dest.UserDto, m => m.MapFrom(dest => dest.User))
                .ForMember(dest => dest.ActivityDto, m => m.MapFrom(dest => dest.Activity));

            });

            var mapper = new Mapper(config);
            var mappedData = mapper.Map<List<User_Activity>, List<UserActivityDto>>(result);

            return Created(string.Empty, mappedData);
        }

    }
}

