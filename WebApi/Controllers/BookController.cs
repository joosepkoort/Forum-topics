using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Interfaces;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/City
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _bookService.GetAll());
        }

        // GET: api/City/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _bookService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        // POST: api/City
        [HttpPost]
        public IHttpActionResult Post([FromBody] ForumTopicDTO bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            var ret = _bookService.AddNewBook(bookDto: bookDto);
            if (ret == null)
            {
                return BadRequest(message: _bookService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        // PUT: api/City/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] ForumTopicDTO cityDto)
        {
            if (cityDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            if (!_bookService.Update(bookDto: cityDto))
            {
                return BadRequest(message: _bookService.LastErrorMessage);
            }
            return Ok(content: "Update Successful"); 
        }

        // DELETE: api/City/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!_bookService.DeleteById(id: id))
            {
                return BadRequest(message: "Couldn't find your object.");
            }
            return Ok(content: "Delete successful");
        }
    }
}
