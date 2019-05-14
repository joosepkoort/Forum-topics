using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.RegionService;

namespace WebApi.Controllers.Api
{
    public class RegionController : ApiController
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GET: api/Region
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _regionService.GetAll());
        }

        // GET: api/Region/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _regionService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/Region
        [HttpPost]
        public IHttpActionResult Post([FromBody] RegionDTO regionDto)
        {
            var ret = _regionService.AddNewRegion(regionDto: regionDto);
            if (ret == null)
            {
                return BadRequest(message: _regionService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/Region/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] RegionDTO regionDto)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Region/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
