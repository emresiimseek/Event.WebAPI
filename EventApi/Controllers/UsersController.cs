using Event.Business.Abstract;
using Event.Core.Utilities.Mapper;
using Event.DataAccsess;
using Event.DataAccsess.Abstract;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Event.WebAPI.Filters;
using EventApi.Filters.FluentValidation;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]

    public class UsersController : ControllerBase
    {

        private IUserService _userService { get; set; }
        private IAutoMapper _autoMapper { get; set; }

        public UsersController(IUserService userService, IAutoMapper autoMapper)
        {
            _userService = userService;
            _autoMapper = autoMapper;
        }

        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = _autoMapper.MapToSameType<UserDto, User>(userDto);
            var result = await _userService.AddAsync(user);
            var addedUser = _autoMapper.MapToSameType<IServiceResponseModel<User>, IServiceResponseDto<UserDto>>(result);

            return Created(string.Empty, result);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IsExistFilter<User>))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            return Ok(_autoMapper.MapToSameList<User, UserDto>(result.Model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(_autoMapper.MapToSameList<User, UserDto>(result.Model));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(IsExistFilter<User>))]

        public async Task<IActionResult> Update(UserDto userDto, int Id)
        {
            _userService.Update(_autoMapper.MapToSameType<UserDto, User>(userDto));


            return NoContent();
        }

    }
}
