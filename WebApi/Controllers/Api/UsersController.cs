using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.UserService;
using Interfaces;

namespace WebApi.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<controller>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _userService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _userService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post([FromBody] UserDTO userDto)
        {
            var ret = _userService.AddNewUser(userDto: userDto);
            if (ret == null)
            {
                return BadRequest(message: _userService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new {id = ret.Id}, content: ret);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] TakenNumberDTO userDto)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}