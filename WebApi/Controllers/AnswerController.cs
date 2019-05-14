using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.DTOs;
using BL.Interfaces;

namespace WebApi.Controllers
{
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _answerService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _answerService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        [HttpGet]
        [Route(template: "api/Answer/find/byAuthor/{author}")]
        public IHttpActionResult FindAnswerByAuthor(string author)
        {
            return Ok(content: _answerService.FindAnswersbyAuthor(author: author));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AnswerDTO answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            var ret = _answerService.AddNewAnswer(answerDTO: answerDto);
            if (ret == null)
            {
                return BadRequest(message: _answerService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] AnswerDTO answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            if (!_answerService.Update(answerDTO: answerDto))
            {
                return BadRequest(message: _answerService.LastErrorMessage);
            }
            return Ok(content: "Update Successful");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!_answerService.DeleteById(id: id))
            {
                return BadRequest(message: "Couldn't find your object.");
            }
            return Ok(content: "Delete successful");
        }
    }
}