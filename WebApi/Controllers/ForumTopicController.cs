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
    public class ForumTopicController : ApiController
    {
        private readonly IForumTopicService _forumTopicService;

        public ForumTopicController(IForumTopicService forumTopicService)
        {
            _forumTopicService = forumTopicService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(content: _forumTopicService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = _forumTopicService.GetById(id: id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        [HttpGet]
        [Route(template: "api/ForumTopic/find/byTitle/{heading}")]
        public IHttpActionResult FindByIdCode(string heading)
        {
            var result = _forumTopicService.FindTopicByTitle(heading: heading);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        [HttpGet]
        [Route(template: "api/ForumTopic/find/byAuthor/{author}")]
        public IHttpActionResult FindByAuthor(string author)
        {
            var result = _forumTopicService.FindTopicByAuthor(author: author);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(content: result);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ForumTopicDTO forumTopicDto)
        {
            if (forumTopicDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            var ret = _forumTopicService.AddNewTopic(forumTopicDTO: forumTopicDto);
            if (ret == null)
            {
                return BadRequest(message: _forumTopicService.LastErrorMessage);
            }
            return CreatedAtRoute(routeName: "DefaultApi", routeValues: new { id = ret.Id }, content: ret);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] ForumTopicDTO forumTopicDto)
        {
            if (forumTopicDto == null)
            {
                return BadRequest(message: "Body was empty!");
            }
            if (!_forumTopicService.Update(forumTopicDTO: forumTopicDto))
            {
                return BadRequest(message: _forumTopicService.LastErrorMessage);
            }
            return Ok(content: "Update Successful");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!_forumTopicService.DeleteById(id: id))
            {
                return BadRequest(message: "Couldn't find your object.");
            }
            return Ok(content: "Delete successful");
        }
    }
}