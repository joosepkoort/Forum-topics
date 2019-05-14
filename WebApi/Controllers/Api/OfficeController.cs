using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.OfficeService;
using BL.Services.TakenNumbersService;
using Interfaces;

namespace WebApi.Controllers.Api
{
    public class OfficeController : ApiController
    {
        private readonly IOfficeService _officeService;


        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        // GET: api/Office
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _officeService.GetAll());
        }

        // GET: api/Office/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _officeService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/Office
        [HttpPost]
        public IHttpActionResult Post([FromBody] OfficeDTO officeDto)
        {
            var ret = _officeService.AddNewOffice(officeDto: officeDto);
            if (ret == null)
            {
                return BadRequest(message: _officeService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/Office/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] OfficeDTO officeDto)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Office/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
