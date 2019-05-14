using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Services.CompanyService;
using Interfaces;

namespace WebApi.Controllers.Api
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Company
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _companyService.GetAll());
        }

        // GET: api/Company/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _companyService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/Company
        [HttpPost]
        public IHttpActionResult Post([FromBody] CompanyDTO companyDto)
        {
            var ret = _companyService.AddNewCompany(companyDto: companyDto);
            if (ret == null)
            {
                return BadRequest(message: _companyService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }


        // PUT: api/Company/5
        [HttpPut]
        public IHttpActionResult Put([FromBody] CompanyDTO companyDto)
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
