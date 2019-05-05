using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Me.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Me.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet("getusers")]
        public ActionResult GetUsers()
        {
            var users = _userService.FindAll();
            return Ok(users);
        }

        [HttpGet("getuser/{id}")]
        public ActionResult GetUser(int id)
        {
            var user = _userService.FindByID(id);
            return Ok(user);
        }
    }
}