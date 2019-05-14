using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.TakenNumbersService;
using Interfaces;

namespace WebApi.Controllers.Api
{
    public class TakenNumbersController : ApiController
    {
        private readonly ITakenNumberService _takenNumberService;

        public TakenNumbersController(ITakenNumberService takenNumberService)
        {
            _takenNumberService = takenNumberService;
        }
        // GET: api/TakenNumbers
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _takenNumberService.GetAll());
        }

        // GET: api/TakenNumbers/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _takenNumberService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/TakenNumbers
        [HttpPost]
        public IHttpActionResult Post([FromBody] TakenNumberDTO userDto)
        {
            var ret = _takenNumberService.AddNewTakenNumber(takenNumberDto: userDto);
            if (ret == null)
            {
                return BadRequest(message: _takenNumberService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/TakenNumbers/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] TakenNumberDTO userDto)
        {
            throw new NotImplementedException();
        }
        // DELETE: api/TakenNumbers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
