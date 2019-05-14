using BL.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ObjectFactories
{
    public class ForumTopicFactory
    {
        public ForumTopicDTO Create(ForumTopic forumTopic)
        {
            return new ForumTopicDTO()
            {
                Id = forumTopic.Id,
                Title = forumTopic.Title,
                Intro = forumTopic.Intro,
                Body = forumTopic.Body,
                Created = forumTopic.Created,
                Author = forumTopic.Author,
                IsActive = forumTopic.IsActive
            };
        }

        public ForumTopic Create(ForumTopicDTO forumTopicDto)
        {
            return new ForumTopic()
            {
                Id = forumTopicDto.Id,
                Title = forumTopicDto.Title,
                Intro = forumTopicDto.Intro,
                Body = forumTopicDto.Body,
                Created = forumTopicDto.Created,
                Author = forumTopicDto.Author,
                IsActive = forumTopicDto.IsActive
            };
        }
    }
}
