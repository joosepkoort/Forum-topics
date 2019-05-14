using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.CityService;

namespace WebApi.Controllers.Api
{
    public class CityController : ApiController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/City
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _cityService.GetAll());
        }

        // GET: api/City/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _cityService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/City
        [HttpPost]
        public IHttpActionResult Post([FromBody] CityDTO cityDto)
        {
            var ret = _cityService.AddNewRegion(cityDto: cityDto);
            if (ret == null)
            {
                return BadRequest(message: _cityService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/City/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] CityDTO cityDto)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/City/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
