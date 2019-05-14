using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.UserFavouriteService;
using Domain;

namespace WebApi.Controllers.Api
{
    public class UserFavouriteController : ApiController
    {

        private readonly IUserFavouriteService _userFavouriteService;

        public UserFavouriteController(IUserFavouriteService userFavouriteService)
        {
            _userFavouriteService = userFavouriteService;
        }

        // GET: api/UserFavourite
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _userFavouriteService.GetAll());
        }

        // GET: api/UserFavourite/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _userFavouriteService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/UserFavourite
        public IHttpActionResult Post([FromBody] UserFavouriteDTO userFavouriteDto)
        {
            var ret = _userFavouriteService.AddNewUserFavourite(userFavouriteDto);
            if (ret == null)
            {
                return BadRequest(message: _userFavouriteService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/UserFavourite/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] UserFavouriteDTO userFavouriteDto)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/UserFavourite/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
