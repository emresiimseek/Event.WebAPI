using Event.Business.Abstract;
using Event.Core.Utilities.Mapper;
using Event.Entities;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using EventApi.Filters.FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAutoMapper _autoMapper { get; set; }
        private IUserService _userService { get; set; }

        public AuthenticationController(IAutoMapper autoMapper, IUserService userService)
        {
            this._autoMapper = autoMapper;
            this._userService = userService;
        }

        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> Authenticate(UserAuthenticationDto userDto)
        {
            var result = await _userService.Authenticate(userDto.UserName, userDto.Password);

            var data = _autoMapper.MapToSameList<User, UserAuthenticationDto>(result.Model);

            var responseDto = new ServiceResponseDto<UserAuthenticationDto> { Errors = result.Errors, Model = data };
            return Ok(responseDto);

        }

    }
}
