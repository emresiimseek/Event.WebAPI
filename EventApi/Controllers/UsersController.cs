using Event.Business.Abstract;
using Event.Core.Utilities.Mapper;
using Event.DataAccsess;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Event.WebAPI.Filters;
using EventApi.Filters.FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public IUserService _userService { get; set; }
        public IAutoMapper _autoMapper { get; set; }

        public UsersController(IUserService userService, IAutoMapper autoMapper)
        {
            _userService = userService;
            _autoMapper = autoMapper;
        }

        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = _autoMapper.MapToSameTpe<UserDto, User>(userDto);

            var result = await _userService.AddAsync(user);

            var addedUser = _autoMapper.MapToSameTpe<User, UserDto>(result);

            return Created(string.Empty, addedUser);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IsExistFilter<User>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_autoMapper.MapToSameTpe<User, UserDto>(await _userService.GetByIdAsync(id)));
        }

    }
}
