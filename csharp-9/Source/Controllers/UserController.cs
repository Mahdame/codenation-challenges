using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if (accelerationName != null && !companyId.HasValue)
            {
                return Ok(_mapper.Map<List<UserDTO>>(_userService.FindByAccelerationName(accelerationName)));
            }
            else if (companyId != null && accelerationName == null)
            {
                return Ok(_mapper.Map<List<UserDTO>>(_userService.FindByCompanyId(companyId.Value)));
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(_mapper.Map<UserDTO>(_userService.FindById(id)));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            var userValue = _mapper.Map<User>(value);
            var saveUser = _userService.Save(userValue);
            var userMap = _mapper.Map<UserDTO>(saveUser);
            return Ok(userMap);
        }
    }
}
