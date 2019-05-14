using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.CompanyTypeService;
using Interfaces;

namespace WebApi.Controllers.Api
{
    public class CompanyTypeController : ApiController
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeController(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }

        // GET: api/Company
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _companyTypeService.GetAll());
        }

        // GET: api/Company/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _companyTypeService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/Company
        [HttpPost]
        public IHttpActionResult Post([FromBody] CompanyTypeDTO companyTypeDto)
        {
            var ret = _companyTypeService.AddNewCompanyType(companyTypeDto: companyTypeDto);
            if (ret == null)
            {
                return BadRequest(message: _companyTypeService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }


        // PUT: api/Company/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] CompanyTypeDTO companyTypeDto)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Company/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
